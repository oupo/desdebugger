namespace desdebugger
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBp = new System.Windows.Forms.TextBox();
            this.buttonBp = new System.Windows.Forms.Button();
            this.listBoxDisasm = new System.Windows.Forms.ListBox();
            this.textBoxGoto = new System.Windows.Forms.TextBox();
            this.buttonGoto = new System.Windows.Forms.Button();
            this.listViewReg = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.radioButtonARM = new System.Windows.Forms.RadioButton();
            this.radioButtonThumb = new System.Windows.Forms.RadioButton();
            this.buttonStepOver = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(14, 54);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(111, 33);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonStep
            // 
            this.buttonStep.Location = new System.Drawing.Point(131, 54);
            this.buttonStep.Name = "buttonStep";
            this.buttonStep.Size = new System.Drawing.Size(111, 33);
            this.buttonStep.TabIndex = 1;
            this.buttonStep.Text = "Step Into";
            this.buttonStep.UseVisualStyleBackColor = true;
            this.buttonStep.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Break Point";
            // 
            // textBoxBp
            // 
            this.textBoxBp.Location = new System.Drawing.Point(99, 104);
            this.textBoxBp.Name = "textBoxBp";
            this.textBoxBp.Size = new System.Drawing.Size(127, 22);
            this.textBoxBp.TabIndex = 3;
            // 
            // buttonBp
            // 
            this.buttonBp.Location = new System.Drawing.Point(232, 103);
            this.buttonBp.Name = "buttonBp";
            this.buttonBp.Size = new System.Drawing.Size(63, 23);
            this.buttonBp.TabIndex = 5;
            this.buttonBp.Text = "Set";
            this.buttonBp.UseVisualStyleBackColor = true;
            this.buttonBp.Click += new System.EventHandler(this.buttonBp_click);
            // 
            // listBoxDisasm
            // 
            this.listBoxDisasm.FormattingEnabled = true;
            this.listBoxDisasm.ItemHeight = 15;
            this.listBoxDisasm.Location = new System.Drawing.Point(14, 135);
            this.listBoxDisasm.Name = "listBoxDisasm";
            this.listBoxDisasm.Size = new System.Drawing.Size(584, 454);
            this.listBoxDisasm.TabIndex = 6;
            this.listBoxDisasm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxDisasm_KeyDown);
            this.listBoxDisasm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxDisasm_KeyPress);
            this.listBoxDisasm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxDisasm_KeyUp);
            // 
            // textBoxGoto
            // 
            this.textBoxGoto.Location = new System.Drawing.Point(328, 104);
            this.textBoxGoto.Name = "textBoxGoto";
            this.textBoxGoto.Size = new System.Drawing.Size(127, 22);
            this.textBoxGoto.TabIndex = 7;
            // 
            // buttonGoto
            // 
            this.buttonGoto.Location = new System.Drawing.Point(461, 104);
            this.buttonGoto.Name = "buttonGoto";
            this.buttonGoto.Size = new System.Drawing.Size(63, 23);
            this.buttonGoto.TabIndex = 8;
            this.buttonGoto.Text = "Goto";
            this.buttonGoto.UseVisualStyleBackColor = true;
            this.buttonGoto.Click += new System.EventHandler(this.buttonGoto_Click);
            // 
            // listViewReg
            // 
            this.listViewReg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.listViewReg.Location = new System.Drawing.Point(642, 135);
            this.listViewReg.Name = "listViewReg";
            this.listViewReg.Size = new System.Drawing.Size(238, 454);
            this.listViewReg.TabIndex = 9;
            this.listViewReg.UseCompatibleStateImageBehavior = false;
            this.listViewReg.View = System.Windows.Forms.View.Details;
            this.listViewReg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewReg_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 163;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "No.";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(53, 29);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "1234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Port";
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(160, 29);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(148, 23);
            this.buttonLaunch.TabIndex = 15;
            this.buttonLaunch.Text = "Launch DeSmuME";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(315, 28);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 16;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // radioButtonARM
            // 
            this.radioButtonARM.AutoSize = true;
            this.radioButtonARM.Checked = true;
            this.radioButtonARM.Location = new System.Drawing.Point(539, 107);
            this.radioButtonARM.Name = "radioButtonARM";
            this.radioButtonARM.Size = new System.Drawing.Size(57, 19);
            this.radioButtonARM.TabIndex = 17;
            this.radioButtonARM.TabStop = true;
            this.radioButtonARM.Text = "ARM";
            this.radioButtonARM.UseVisualStyleBackColor = true;
            this.radioButtonARM.CheckedChanged += new System.EventHandler(this.radioButtonARM_CheckedChanged);
            // 
            // radioButtonThumb
            // 
            this.radioButtonThumb.AutoSize = true;
            this.radioButtonThumb.Location = new System.Drawing.Point(602, 108);
            this.radioButtonThumb.Name = "radioButtonThumb";
            this.radioButtonThumb.Size = new System.Drawing.Size(71, 19);
            this.radioButtonThumb.TabIndex = 18;
            this.radioButtonThumb.Text = "Thumb";
            this.radioButtonThumb.UseVisualStyleBackColor = true;
            this.radioButtonThumb.CheckedChanged += new System.EventHandler(this.radioButtonThumb_CheckedChanged);
            // 
            // buttonStepOver
            // 
            this.buttonStepOver.Location = new System.Drawing.Point(248, 54);
            this.buttonStepOver.Name = "buttonStepOver";
            this.buttonStepOver.Size = new System.Drawing.Size(111, 33);
            this.buttonStepOver.TabIndex = 19;
            this.buttonStepOver.Text = "Step Over";
            this.buttonStepOver.UseVisualStyleBackColor = true;
            this.buttonStepOver.Click += new System.EventHandler(this.buttonStepOver_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(602, 135);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 454);
            this.vScrollBar1.TabIndex = 20;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 601);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.buttonStepOver);
            this.Controls.Add(this.radioButtonThumb);
            this.Controls.Add(this.radioButtonARM);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.listViewReg);
            this.Controls.Add(this.buttonGoto);
            this.Controls.Add(this.textBoxGoto);
            this.Controls.Add(this.listBoxDisasm);
            this.Controls.Add(this.buttonBp);
            this.Controls.Add(this.textBoxBp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStep);
            this.Controls.Add(this.buttonContinue);
            this.Name = "Form1";
            this.Text = "desdebugger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBp;
        private System.Windows.Forms.Button buttonBp;
        private System.Windows.Forms.ListBox listBoxDisasm;
        private System.Windows.Forms.TextBox textBoxGoto;
        private System.Windows.Forms.Button buttonGoto;
        private System.Windows.Forms.ListView listViewReg;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.RadioButton radioButtonARM;
        private System.Windows.Forms.RadioButton radioButtonThumb;
        private System.Windows.Forms.Button buttonStepOver;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

