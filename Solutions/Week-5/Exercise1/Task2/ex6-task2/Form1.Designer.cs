namespace task2
{
    partial class Form1
    {
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstMessages;

        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // txtUser
            this.txtUser.Location = new System.Drawing.Point(12, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "Enter your name";
            this.txtUser.Size = new System.Drawing.Size(200, 23);

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(12, 41);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "Type your message";
            this.txtMessage.Size = new System.Drawing.Size(300, 23);

            // btnSend
            this.btnSend.Location = new System.Drawing.Point(318, 41);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // lstMessages
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 15;
            this.lstMessages.Location = new System.Drawing.Point(12, 70);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(381, 169);

            // Form1
            this.ClientSize = new System.Drawing.Size(405, 250);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lstMessages);
            this.Name = "Form1";
            this.Text = "Kafka Chat Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}