namespace RegWhatsAppOpenCv
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            LogBox = new TextBox();
            Test = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(320, 11);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "  START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += button1_Click;
            // 
            // LogBox
            // 
            LogBox.AccessibleRole = AccessibleRole.ScrollBar;
            LogBox.BackColor = SystemColors.MenuText;
            LogBox.ForeColor = Color.Lime;
            LogBox.Location = new Point(12, 12);
            LogBox.Multiline = true;
            LogBox.Name = "LogBox";
            LogBox.Size = new Size(302, 426);
            LogBox.TabIndex = 1;
            // 
            // Test
            // 
            Test.Location = new Point(320, 40);
            Test.Name = "Test";
            Test.Size = new Size(75, 23);
            Test.TabIndex = 2;
            Test.Text = "BALANCE";
            Test.UseVisualStyleBackColor = true;
            Test.Click += button2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 450);
            Controls.Add(Test);
            Controls.Add(LogBox);
            Controls.Add(btnStart);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public static Button btnStart;
        private Button Test;
        public static TextBox LogBox;
    }
}