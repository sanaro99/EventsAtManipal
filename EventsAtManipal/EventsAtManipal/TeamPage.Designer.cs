namespace EventsAtManipal
{
    partial class TeamPage
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
            this.team = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.generate = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.EventNameLabel = new System.Windows.Forms.Label();
            this.ParticipantIDLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // team
            // 
            this.team.Location = new System.Drawing.Point(302, 272);
            this.team.Name = "team";
            this.team.Size = new System.Drawing.Size(100, 20);
            this.team.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your ID : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Event : ";
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(213, 218);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(153, 23);
            this.generate.TabIndex = 3;
            this.generate.Text = "Click to generate Team ID";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.button1_Click);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(213, 384);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(100, 33);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Team ID : ";
            // 
            // EventNameLabel
            // 
            this.EventNameLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EventNameLabel.Location = new System.Drawing.Point(269, 126);
            this.EventNameLabel.Name = "EventNameLabel";
            this.EventNameLabel.Size = new System.Drawing.Size(113, 22);
            this.EventNameLabel.TabIndex = 6;
            // 
            // ParticipantIDLabel
            // 
            this.ParticipantIDLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ParticipantIDLabel.Location = new System.Drawing.Point(269, 55);
            this.ParticipantIDLabel.Name = "ParticipantIDLabel";
            this.ParticipantIDLabel.Size = new System.Drawing.Size(113, 20);
            this.ParticipantIDLabel.TabIndex = 7;
            // 
            // TeamPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ParticipantIDLabel);
            this.Controls.Add(this.EventNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.team);
            this.Name = "TeamPage";
            this.Text = "TeamPage";
            this.Load += new System.EventHandler(this.TeamPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox team;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label EventNameLabel;
        private System.Windows.Forms.Label ParticipantIDLabel;
    }
}