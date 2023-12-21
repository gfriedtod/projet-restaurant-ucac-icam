using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ClientSocket
{
    public Socket socket { get; set; }
    private IPEndPoint ipEndPoint { get; set; }

    public ClientSocket()
    {
        // Créez un point d'extrémité pour se connecter au serveur.
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 13000; 
        ipEndPoint = new IPEndPoint(ipAddress, port);
        socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }
    
    public void Connect()
    {
        socket.Connect(ipEndPoint);
    }

    public string Send(Object data)
    {
       // string data = "Bonjour, ceci est le client socket.";
        byte[] msg = Encoding.ASCII.GetBytes((string)data);
        socket.Send(msg);

        byte[] bytes = new byte[1024];
        int bytesRec = socket.Receive(bytes);
        
        return Encoding.ASCII.GetString(bytes, 0, bytesRec);

    }

    

    public static void Main()
    {
        // Créez un point d'extrémité pour se connecter au serveur.
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 13000;
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

        // Créez un socket TCP/IP.
        using (Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
        {
            // Connectez-vous au serveur.
            client.Connect(ipEndPoint);

            // Envoyez et recevez des données du serveur.
            string data = "Bonjour, ceci est le client socket.";
            byte[] msg = Encoding.ASCII.GetBytes(data);
            client.Send(msg);

            byte[] bytes = new byte[1024];
            int bytesRec = client.Receive(bytes);
            Console.WriteLine("Message du serveur : {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

            // Fermez le socket.
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
