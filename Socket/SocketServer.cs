using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketExt
{
    public partial class SocketServer : Form
    {
        Socket socketServer;//服务端
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//客户端

        public SocketServer()
        {
            InitializeComponent();
        }

        private void CreateSocketServer_Click(object sender, EventArgs e)
        {
            //ip地址
            IPAddress ip = IPAddress.Parse(tbIP.Text);
            // IPAddress ip = IPAddress.Any;
            //端口号
            IPEndPoint point = new IPEndPoint(ip, int.Parse(tbPort.Text));

            //创建监听用的Socket
            /*
             * AddressFamily.InterNetWork：使用 IP4地址。
                SocketType.Stream：支持可靠、双向、基于连接的字节流，而不重复数据。此类型的 Socket 与单个对方主机进行通信，并且在通信开始之前需要远程主机连接。Stream 使用传输控制协议 (Tcp) ProtocolType 和 InterNetworkAddressFamily。
                ProtocolType.Tcp：使用传输控制协议。
             */

            //使用IPv4地址，流式socket方式，tcp协议传递数据
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //创建好socket后，必须告诉socket绑定的IP地址和端口号。

            //让socket监听point
            try
            {
                //socket监听哪个端口
                socketServer.Bind(point);

                //同一个时间点过来10个客户端，排队
                socketServer.Listen(10);

                ShowMsg("服务器开始监听");

                Thread thread = new Thread(AcceptInfo);
                thread.IsBackground = true;
                thread.Start(socketServer);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        //记录通信用的Socket

        Dictionary<string, Socket> dic = new Dictionary<string, Socket>();

        public void AcceptInfo(object o)
        {
            Socket socket = o as Socket;
            while (true)
            {
                //通信用socket
                try
                {
                    //创建通信用的Socket
                    Socket tSocket = socket.Accept();

                    string point = tSocket.RemoteEndPoint.ToString();

                    //IPEndPoint endPoint = (IPEndPoint)client.RemoteEndPoint;
                    //string me = Dns.GetHostName();//得到本机名称
                    //MessageBox.Show(me);

                    ShowMsg(point + "连接成功！");

                    addCboIpPort(point);

                    dic.Add(point, tSocket);

                    //接收消息
                    Thread th = new Thread(ReceiveMsg);
                    th.IsBackground = true;
                    th.Start(tSocket);
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }

        //接收消息
        void ReceiveMsg(object o)
        {
            Socket client = o as Socket;
            while (true)
            {
                //接收客户端发送过来的数据
                try
                {
                    //定义byte数组存放从客户端接收过来的数据
                    byte[] buffer = new byte[1024 * 1024];

                    //将接收过来的数据放到buffer中，并返回实际接受数据的长度
                    int n = client.Receive(buffer);

                    //将字节转换成字符串
                    string words = Encoding.UTF8.GetString(buffer, 0, n);

                    ShowMsg(client.RemoteEndPoint.ToString() + ":" + words);
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }

        public void ShowMsg(string msg)
        {
            //tbLog.AppendText(msg + "\r\n");

            //C#中窗体控件默认只能从主线程中访问，如果要从别的线程中访问必须要使用 BeginInvoke 用制定的参数异步制定委托  
            //获取一个值，该值指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中。  
            if (this.InvokeRequired)
            {
                Action<string> dg = ShowMsg;
                //在创建控件的基础句柄所在线程上，用指定的参数异步执行指定委托。  
                this.BeginInvoke(dg, msg);
            }
            else
            {
                tbLog.AppendText(msg + ";\r\n");
            }
        }

        public void addCboIpPort(string msg)
        {
            lock (this)
                Invoke(new MethodInvoker(delegate ()
                {
                    cboIpPort.Items.Add(msg);
                }));
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMsg(tbMsg.Text);

                string ip = cboIpPort.Text;

                byte[] buffer = Encoding.UTF8.GetBytes(tbMsg.Text);

                dic[ip].Send(buffer);

                // client.Send(buffer);

                tbMsg.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        private void btnBav_Click(object sender, EventArgs e)
        {
            //镭雕板到达
            tbMsg.Text = "#!BOARDAV    /n/r";
        }

        private void SocketServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //socketServer.Shutdown(SocketShutdown.Both);
            //socketServer.Close();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            //连接到的目标IP
            IPAddress ip = IPAddress.Parse(tbIP.Text);
            //IPAddress ip = IPAddress.Any;

            //连接到目标IP的哪个应用(端口号！)
            IPEndPoint point = new IPEndPoint(ip, int.Parse(tbPort.Text));

            try
            {
                //连接到服务器
                client.Connect(point);

                ShowMsg("连接成功");

                ShowMsg("服务器" + client.RemoteEndPoint.ToString());

                ShowMsg("客户端:" + client.LocalEndPoint.ToString());

                //连接成功后，就可以接收服务器发送的信息了
                Thread th = new Thread(clientReceiveMsg);
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        int runCount = 0;

        void clientReceiveMsg(object o)
        {
            while (true)
            {
                //接收客户端发送过来的数据
                try
                {
                    //定义byte数组存放从客户端接收过来的数据
                    byte[] buffer = new byte[1024 * 1024];

                    //将接收过来的数据放到buffer中，并返回实际接受数据的长度
                    int n = client.Receive(buffer);

                    if (n == 0 && runCount > 10)
                    {
                        continue;
                    }
                    else if (n == 0 && runCount <= 10)
                    {
                        runCount++;
                    }

                    //将字节转换成字符串
                    string words = Encoding.UTF8.GetString(buffer, 0, n);

                    ShowMsg(client.RemoteEndPoint.ToString() + ":" + words);
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }

        private void clientSend_Click(object sender, EventArgs e)
        {
            //客户端给服务器发消息
            if (client != null)
            {
                try
                {
                    ShowMsg(tbMsg.Text);

                    byte[] buffer = Encoding.UTF8.GetBytes(tbMsg.Text);

                    client.Send(buffer);

                    tbMsg.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                }
            }
        }
    }
    
}
