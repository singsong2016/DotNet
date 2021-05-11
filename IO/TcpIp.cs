static void Main(string[] args)
  {
      Task.Factory.StartNew(TcpServer);

      client();

  }

  static void TcpServer()
  {
      var a = new TcpListener(IPAddress.Parse("127.0.0.1"), 1028);

      a.Start();
      Console.WriteLine("started");

      while (true)
      {
          var c = a.AcceptTcpClient();

          while (c.Connected)
          {

              try
              {
                  var buffer = new byte[c.ReceiveBufferSize];

                  var len = c.Client.Receive(buffer);

                  var s = Encoding.UTF8.GetString(buffer, 0, len);

                  Console.WriteLine(s);

                  Console.WriteLine(c.Client.RemoteEndPoint);

                  c.Client.Send(Encoding.UTF8.GetBytes(s.Length.ToString()));

              }
              catch (ArgumentException)
              {
                  Console.WriteLine("disconnected");
              }

          }

      }
  }

  static void client()
  {
      var a = new TcpClient("127.0.0.1", 1028);

      while (a.Connected)
      {
          var s = Console.ReadLine();

          a.Client.Send(Encoding.UTF8.GetBytes(s));

          var buffer = new byte[a.ReceiveBufferSize];

          var len = a.Client.Receive(buffer);

          var result = Encoding.UTF8.GetString(buffer, 0, len);

          Console.WriteLine(result);

      }
  }
