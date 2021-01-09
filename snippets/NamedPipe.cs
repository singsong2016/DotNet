Server:

 public static void Main()
        {
            NamedPipeServerStream pipeServer =
                new NamedPipeServerStream("testpipe", PipeDirection.InOut, 1);
            pipeServer.WaitForConnection();


            while (pipeServer.IsConnected)
            {

                var a = Encoding.ASCII.GetBytes("server send msg");
                pipeServer.Write(a, 0, a.Length);


                var bu = new byte[1000];
                var l = pipeServer.Read(bu, 0, bu.Length);
                var s = Encoding.ASCII.GetString(bu, 0, l);
                Console.WriteLine(s);

            }
 Client:
 
  public static void Main(string[] args)
        {
            var a = new NamedPipeClientStream("127.0.0.1", "testpipe", PipeDirection.InOut);

            a.Connect();

            while (a.IsConnected)
            {
                var bu = new byte[1000];
                var l = a.Read(bu, 0, bu.Length);
                var s = Encoding.ASCII.GetString(bu, 0, l);
                Console.WriteLine(s);

                var ss = Encoding.ASCII.GetBytes("client");
                a.Write(ss, 0, ss.Length);
                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }
