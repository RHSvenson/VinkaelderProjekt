namespace TestProject
{
    partial class clockEditor
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
            this.currClocks = new System.Windows.Forms.ListBox();
            this.possibleClocks = new System.Windows.Forms.ListBox();
            this.addClock = new System.Windows.Forms.Button();
            this.rmvClock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currClocks
            // 
            this.currClocks.FormattingEnabled = true;
            this.currClocks.Location = new System.Drawing.Point(12, 29);
            this.currClocks.Name = "currClocks";
            this.currClocks.Size = new System.Drawing.Size(212, 186);
            this.currClocks.TabIndex = 1;
            // 
            // possibleClocks
            // 
            this.possibleClocks.FormattingEnabled = true;
            this.possibleClocks.Location = new System.Drawing.Point(311, 29);
            this.possibleClocks.Name = "possibleClocks";
            this.possibleClocks.Size = new System.Drawing.Size(224, 186);
            this.possibleClocks.TabIndex = 2;
            // 
            // addClock
            // 
            this.addClock.Location = new System.Drawing.Point(231, 29);
            this.addClock.Name = "addClock";
            this.addClock.Size = new System.Drawing.Size(75, 23);
            this.addClock.TabIndex = 3;
            this.addClock.Text = "<==";
            this.addClock.UseVisualStyleBackColor = true;
            this.addClock.Click += new System.EventHandler(this.addClock_Click);
            // 
            // rmvClock
            // 
            this.rmvClock.Location = new System.Drawing.Point(230, 192);
            this.rmvClock.Name = "rmvClock";
            this.rmvClock.Size = new System.Drawing.Size(75, 23);
            this.rmvClock.TabIndex = 4;
            this.rmvClock.Text = "==>";
            this.rmvClock.UseVisualStyleBackColor = true;
            this.rmvClock.Click += new System.EventHandler(this.rmvClock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // clockEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 229);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rmvClock);
            this.Controls.Add(this.addClock);
            this.Controls.Add(this.possibleClocks);
            this.Controls.Add(this.currClocks);
            this.Name = "clockEditor";
            this.Text = "Clock Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox currClocks;
        private System.Windows.Forms.ListBox possibleClocks;
        private System.Windows.Forms.Button addClock;
        private System.Windows.Forms.Button rmvClock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}