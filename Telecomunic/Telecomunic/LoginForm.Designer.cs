namespace Telecomunic
{
    partial class LoginForm
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
            this.parolaTxt = new System.Windows.Forms.TextBox();
            this.submitTxt = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numeTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // parolaTxt
            // 
            this.parolaTxt.Location = new System.Drawing.Point(818, 436);
            this.parolaTxt.Name = "parolaTxt";
            this.parolaTxt.PasswordChar = '*';
            this.parolaTxt.Size = new System.Drawing.Size(185, 20);
            this.parolaTxt.TabIndex = 1;
            this.parolaTxt.UseSystemPasswordChar = true;
            // 
            // submitTxt
            // 
            this.submitTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.submitTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitTxt.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.submitTxt.Location = new System.Drawing.Point(843, 521);
            this.submitTxt.Name = "submitTxt";
            this.submitTxt.Size = new System.Drawing.Size(147, 47);
            this.submitTxt.TabIndex = 2;
            this.submitTxt.Text = "Submit";
            this.submitTxt.UseVisualStyleBackColor = false;
            this.submitTxt.Click += new System.EventHandler(this.submitTxt_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.label9.Location = new System.Drawing.Point(717, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 28);
            this.label9.TabIndex = 22;
            this.label9.Text = "Parola: ";
            // 
            // numeTxt
            // 
            this.numeTxt.Location = new System.Drawing.Point(818, 360);
            this.numeTxt.Name = "numeTxt";
            this.numeTxt.Size = new System.Drawing.Size(185, 20);
            this.numeTxt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(674, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "Username: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(833, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 56);
            this.label1.TabIndex = 8;
            this.label1.Text = "Log In";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe Script", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1683, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 54);
            this.button3.TabIndex = 4;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe Script", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1614, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 932);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.parolaTxt);
            this.Controls.Add(this.submitTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numeTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox parolaTxt;
        private System.Windows.Forms.Button submitTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox numeTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}