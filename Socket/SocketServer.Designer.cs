namespace SocketExt
{
    partial class SocketServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.CreateSocketServer = new System.Windows.Forms.Button();
            this.cboIpPort = new System.Windows.Forms.ComboBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnBav = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.clientSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(49, 55);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(184, 21);
            this.tbIP.TabIndex = 0;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(239, 55);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(74, 21);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "50100";
            // 
            // CreateSocketServer
            // 
            this.CreateSocketServer.Location = new System.Drawing.Point(319, 55);
            this.CreateSocketServer.Name = "CreateSocketServer";
            this.CreateSocketServer.Size = new System.Drawing.Size(75, 23);
            this.CreateSocketServer.TabIndex = 2;
            this.CreateSocketServer.Text = "创建监听";
            this.CreateSocketServer.UseVisualStyleBackColor = true;
            this.CreateSocketServer.Click += new System.EventHandler(this.CreateSocketServer_Click);
            // 
            // cboIpPort
            // 
            this.cboIpPort.FormattingEnabled = true;
            this.cboIpPort.Location = new System.Drawing.Point(400, 58);
            this.cboIpPort.Name = "cboIpPort";
            this.cboIpPort.Size = new System.Drawing.Size(147, 20);
            this.cboIpPort.TabIndex = 3;
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(49, 83);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(498, 204);
            this.tbLog.TabIndex = 4;
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(49, 293);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(498, 94);
            this.tbMsg.TabIndex = 5;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(553, 364);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 6;
            this.btnSendMessage.Text = "发送信息";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnBav
            // 
            this.btnBav.Location = new System.Drawing.Point(49, 394);
            this.btnBav.Name = "btnBav";
            this.btnBav.Size = new System.Drawing.Size(75, 23);
            this.btnBav.TabIndex = 7;
            this.btnBav.Text = "镭雕板到达";
            this.btnBav.UseVisualStyleBackColor = true;
            this.btnBav.Click += new System.EventHandler(this.btnBav_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(554, 56);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 23);
            this.btnConnection.TabIndex = 8;
            this.btnConnection.Text = "连接Socket";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // clientSend
            // 
            this.clientSend.Location = new System.Drawing.Point(554, 86);
            this.clientSend.Name = "clientSend";
            this.clientSend.Size = new System.Drawing.Size(75, 23);
            this.clientSend.TabIndex = 9;
            this.clientSend.Text = "Client发送";
            this.clientSend.UseVisualStyleBackColor = true;
            this.clientSend.Click += new System.EventHandler(this.clientSend_Click);
            // 
            // SocketServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 468);
            this.Controls.Add(this.clientSend);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.btnBav);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.cboIpPort);
            this.Controls.Add(this.CreateSocketServer);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.Name = "SocketServer";
            this.Text = "SocketServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SocketServer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button CreateSocketServer;
        private System.Windows.Forms.ComboBox cboIpPort;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnBav;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button clientSend;
    }
}

