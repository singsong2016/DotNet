var tclient = new TcpClient("127.0.0.1", 1028);

tclient.Client.Send(Encoding.UTF8.GetBytes("what are you doing here"));

var b = new Byte[1024];
var length = tclient.Client.Receive(b);
var result = Encoding.UTF8.GetString(b, 0, length);
MessageBox.Show(result);
