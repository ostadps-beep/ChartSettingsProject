[  ] using System;
[  ] using System.Net.Sockets;
[  ] using System.Text;
[  ] 
[  ] public static class PythonBridge
[  ] {
[  ]     public static string Host = "127.0.0.1";
[  ]     public static int Port = 5000;
[  ]     public static int Timeout = 3000;
[  ] 
[  ]     public static void Configure(string host, int port, int timeout)
[  ]     {
[  ]         Host = host;
[  ]         Port = port;
[  ]         Timeout = timeout;
[  ]     }
[  ] 
[  ]     public static void Send(string key, object value)
[  ]     {
[  ]         try
[  ]         {
[  ]             using (TcpClient client = new TcpClient())
[  ]             {
[  ]                 client.ReceiveTimeout = Timeout;
[  ]                 client.SendTimeout = Timeout;
[  ] 
[  ]                 client.Connect(Host, Port);
[  ] 
[  ]                 var stream = client.GetStream();
[  ]                 string message = $"{key}:{value}";
[  ]                 byte[] data = Encoding.UTF8.GetBytes(message);
[  ] 
[  ]                 stream.Write(data, 0, data.Length);
[  ]             }
[  ]         }
[  ]         catch (Exception ex)
[  ]         {
[  ]             Console.WriteLine("PythonBridge Error: " + ex.Message);
[  ]         }
[  ]     }
[  ] }