namespace CatchButton
{
    partial class Form1
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
            runbutton = new Button();
            SuspendLayout();
            // 
            // runbutton
            // 
            runbutton.BackColor = SystemColors.ButtonShadow;
            runbutton.Font = new Font("함초롬돋움", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            runbutton.Location = new Point(279, 183);
            runbutton.Name = "runbutton";
            runbutton.Size = new Size(200, 50);
            runbutton.TabIndex = 0;
            runbutton.Text = "\" 나를 잡아봐 \"";
            runbutton.UseVisualStyleBackColor = false;
            runbutton.Click += runbutton_Click;
            runbutton.MouseDown += runbutton_MouseDown;
            runbutton.MouseEnter += runbutton_MouseEnter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 450);
            Controls.Add(runbutton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button runbutton;
    }
}
