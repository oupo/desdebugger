namespace desdebugger
{
    partial class FormSetRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxRegValue = new System.Windows.Forms.TextBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRegValue
            // 
            this.textBoxRegValue.Location = new System.Drawing.Point(28, 38);
            this.textBoxRegValue.Name = "textBoxRegValue";
            this.textBoxRegValue.Size = new System.Drawing.Size(137, 22);
            this.textBoxRegValue.TabIndex = 0;
            // 
            // buttonChange
            // 
            this.buttonChange.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonChange.Location = new System.Drawing.Point(181, 37);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 1;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            // 
            // FormSetRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 93);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.textBoxRegValue);
            this.Name = "FormSetRegister";
            this.Text = "Change Register Value";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRegValue;
        private System.Windows.Forms.Button buttonChange;
    }
}