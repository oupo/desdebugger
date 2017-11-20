using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace desdebugger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("arm-disasm.dll")]
        static extern void Disasm(uint adr, uint ins, System.Text.StringBuilder str);
        [DllImport("arm-disasm.dll")]
        static extern void DisasmThumb(uint adr, uint ins, System.Text.StringBuilder str);

        private System.Net.Sockets.TcpClient client;
        private uint memoryAdr;
        private uint[] registers;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("desmume.exe", "--arm9gdb " + GetPortNumber());
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            client = new System.Net.Sockets.TcpClient("localhost", GetPortNumber());
            UpdateRegisters();
            GotoWithUpdate(0x02000000);
        }

        private int GetPortNumber()
        {
            return Convert.ToInt32(textBoxPort.Text);
        }

        private int DISASM_LEN = 30;

        private void UpdateDisasm()
        {
            if (client == null) return;
            bool thumb = radioButtonThumb.Checked;
            if (listBoxDisasm.Items.Count != DISASM_LEN)
            {
                listBoxDisasm.Items.Clear();
                for (var i = 0; i < DISASM_LEN; i++)
                {
                    listBoxDisasm.Items.Add("");
                }
            }
            for (var i = 0; i < DISASM_LEN; i++)
            {
                var adr = (uint)(memoryAdr + i * (thumb ? 2 : 4));
                listBoxDisasm.Items[i] = CreateDisasmText(thumb, adr);
            }
            UpdateScroolbarValue();
        }

        private string CreateDisasmText(bool thumb, uint adr)
        {
            var buf = new StringBuilder(256);
            var ins = thumb ? GetMemory16(adr, 1)[0] : GetMemory32(adr, 1)[0];
            if (thumb)
            {
                DisasmThumb(adr, ins, buf);
            }
            else
            {
                Disasm(adr, ins, buf);
            }
            var str = String.Format("{0:x8} ", adr) + buf.ToString().ToLower();
            var match = System.Text.RegularExpressions.Regex.Match(str, @"\[pc, #([0-9a-f]+)\]");
            if (match.Success)
            {
                var ofs = Convert.ToInt32(match.Groups[1].Value, 16);
                if (thumb)
                {
                    str = str.Substring(0, match.Index) + String.Format("#{0:x8}", GetMemory32((uint)(((adr + 4) & ~3) + ofs), 1)[0]);
                }
            }
            return str;
        }

        private void GotoWithUpdate(uint adr)
        {
            bool thumb = radioButtonThumb.Checked;
            memoryAdr = (uint)(adr);
            UpdateDisasm();
        }

        private void Goto(uint adr)
        {
            bool thumb = radioButtonThumb.Checked;
            if (memoryAdr <= adr && adr < memoryAdr + DISASM_LEN * (thumb ? 2 : 4))
            {

            }
            else
            {
                GotoWithUpdate(adr);
            }
            listBoxDisasm.SelectedIndex = (int)(adr - memoryAdr) / (thumb ? 2 : 4);
        }

        private void UpdateRegisters()
        {
            var reg = GetRegisters();
            registers = reg;
            listViewReg.Items.Clear();
            for (var i = 0; i < reg.Length; i++)
            {
                string[] strings = { String.Format("{0:x8}", reg[i]), Convert.ToString(i) };
                var item = new ListViewItem(strings);
                listViewReg.Items.Add(item);
            }
        }

        private uint[] GetMemory16(uint adr, int size)
        {
            var memory = new List<uint>();

            for (int i = 0; i < size; i++)
            {
                var res = Interact(String.Format("m{0:x8},{1:X}", adr + i * 2, 2));
                if (res[0] == 'E')
                {
                    memory.Add(0);
                }
                else
                {
                    memory.Add(Convert.ToUInt32(res.Substring(2, 2) + res.Substring(0, 2), 16));
                }
            }
            return memory.ToArray();
        }

        private uint[] GetMemory32(uint adr, int size)
        {
            var memory = new List<uint>();

            for (int i = 0; i < size; i++)
            {
                var res = Interact(String.Format("m{0:x8},{1:X}", adr + i * 4, 4));
                if (res[0] == 'E')
                {
                    memory.Add(0);
                }
                else
                {
                    memory.Add(Convert.ToUInt32(res.Substring(6, 2) + res.Substring(4, 2) + res.Substring(2, 2) + res.Substring(0, 2), 16));
                }
            }
            return memory.ToArray();
        }

        private uint[] GetRegisters()
        {
            var registers = new List<uint>();
            string res = Interact("g");
            for (int i = 0; i < res.Length / 8; i ++)
            {
                var str = res.Substring(i * 8, 8);
                registers.Add(Convert.ToUInt32(str.Substring(6, 2) + str.Substring(4, 2) + str.Substring(2, 2) + str.Substring(0, 2), 16));
            }
            return registers.ToArray();
        }

        private string Interact(string request)
        {
            //Console.WriteLine(request);
            var stream = client.GetStream();
            
            var bytes = System.Text.Encoding.UTF8.GetBytes("$" + request + "#" + String.Format("{0:X2}", Checksum(request)));
            stream.Write(bytes, 0, bytes.Length);
            var retBytes = new List<byte>();
            int c;
            stream.ReadByte();
            stream.ReadByte();
            while ((c = stream.ReadByte()) != Convert.ToByte('#'))
            {
                retBytes.Add((byte)c);
            }
            stream.ReadByte();
            stream.ReadByte();
            stream.WriteByte(Convert.ToByte('+'));
            var response = System.Text.Encoding.UTF8.GetString(retBytes.ToArray());
            //Console.WriteLine(response);
            return response;
        }

        private int Checksum(string str)
        {
            var chars = str.ToCharArray();
            uint sum = 0;
            foreach (char c in chars)
            {
                sum += c;
            }
            return (int)(sum % 256);
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            Interact("c");
            UpdateRegisters();
            Goto(registers[15]);
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            Interact("s");
            UpdateRegisters();
            Goto(registers[15]);
        }

        private void buttonStepOver_Click(object sender, EventArgs e)
        {
            uint pc = GetRegisters()[15];
            bool thumb = radioButtonThumb.Checked;
            uint destAdr;
            string insName;
            getBranchAddr(pc, out destAdr, out insName);
            Console.WriteLine(destAdr);
            Console.WriteLine(insName);
            if (insName == "bl" || insName == "blx")
            {
                uint targetPC = pc + (uint)(thumb ? 2 : 4);
                do
                {
                    Interact("s");
                    pc = GetRegisters()[15];
                } while (pc != targetPC);
                Goto(pc);
            }
            else
            {
                Interact("s");
                UpdateRegisters();
                Goto(registers[15]);
            }
        }

        private bool getBranchAddr(uint addr, out uint destAdr, out string insName)
        {
            var thumb = radioButtonThumb.Checked;
            var str = CreateDisasmText(thumb, addr);
            Console.WriteLine(str);
            var match = System.Text.RegularExpressions.Regex.Match(str, @"^[0-9a-f]+ (b|bl|blx)(?:eq|ne|cs|cc|mi|pl|vs|vc|hi|ls|ge|lt|gt|le)? #?([0-9a-f]+)");
            if (match.Success)
            {
                insName = match.Groups[1].Value;
                destAdr = Convert.ToUInt32(match.Groups[2].Value, 16);
                return true;
            } else
            {
                insName = "";
                destAdr = 0;
                return false;
            }
        }

        private void buttonBp_click(object sender, EventArgs e)
        {
            Interact(String.Format("Z0,{0:x8},4", Convert.ToUInt32(textBoxBp.Text, 16)));
        }

        private void buttonGoto_Click(object sender, EventArgs e)
        {
            GotoWithUpdate(Convert.ToUInt32(textBoxGoto.Text, 16));
        }

        private void radioButtonARM_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisasm();
        }

        private void radioButtonThumb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisasm();
        }

        private void ChangeRegister(int index, uint value)
        {
            Interact(String.Format("P{0:x}={1:x2}{2:x2}{3:x2}{4:x2}", index, value & 0xff, value >> 8 & 0xff, value >> 16 & 0xff, value >> 24 & 0xff));
        }

        private void listViewReg_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = new FormSetRegister();
            var item = listViewReg.SelectedItems[0];
            form.SetValue(Convert.ToUInt32(item.Text, 16));
            form.ShowDialog(this);
            var value = form.GetValue();
            form.Dispose();
            ChangeRegister(item.Index, value);
            UpdateRegisters();
        }

        private void listBoxDisasm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void listBoxDisasm_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void listBoxDisasm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Up && listBoxDisasm.SelectedIndex == 0)
            {
                DisasmUp();
            }
            if (e.KeyData == Keys.Down && listBoxDisasm.SelectedIndex == DISASM_LEN - 1)
            {
                DisasmDown();
            }
        }

        private void DisasmUp()
        {
            var thumb = radioButtonThumb.Checked;
            memoryAdr = (uint)(memoryAdr - (thumb ? 2 : 4));
            var str = CreateDisasmText(thumb, memoryAdr);
            listBoxDisasm.Items.RemoveAt(DISASM_LEN - 1);
            listBoxDisasm.Items.Insert(0, str);
            UpdateScroolbarValue();
        }

        private void DisasmDown()
        {
            var thumb = radioButtonThumb.Checked;
            memoryAdr = (uint)(memoryAdr + (thumb ? 2 : 4));
            var adr = (uint)(memoryAdr + (DISASM_LEN - 1) * (thumb ? 2 : 4));
            var str = CreateDisasmText(thumb, adr);
            listBoxDisasm.Items.RemoveAt(0);
            listBoxDisasm.Items.Add(str);
            UpdateScroolbarValue();
        }

        const uint MEMORY_MAX = 0x08000000;

        private void UpdateScroolbarValue()
        {
            int value = (int)Math.Round((double)memoryAdr / MEMORY_MAX * vScrollBar1.Maximum);
            if (vScrollBar1.Minimum <= value && value <= vScrollBar1.Maximum) {
               vScrollBar1.Value = value;
            }
        }
        
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue == e.OldValue)
            {
                // do nothing
            }
            else if (e.NewValue == e.OldValue - 1)
            {
                DisasmUp();
            }
            else if (e.NewValue == e.OldValue + 1)
            {
                DisasmDown();
            }
            else
            {
                memoryAdr = (uint)((double)vScrollBar1.Value / vScrollBar1.Maximum * MEMORY_MAX) & unchecked((uint)~3);
                UpdateDisasm();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Interact(String.Format("z0,{0:x8},4", Convert.ToUInt32(textBoxBp.Text, 16)));
        }

        private void listBoxDisasm_Resize(object sender, EventArgs e)
        {
            if (DISASM_LEN != listBoxDisasm.Height / listBoxDisasm.ItemHeight) {
                DISASM_LEN = listBoxDisasm.Height / listBoxDisasm.ItemHeight;
                UpdateDisasm();
            }
        }
    }
}
