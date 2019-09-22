using System.Net;

namespace Application.Client.Entities.Server
{
    class ServerProperties
    {

        private static string SERVER_ADDRESS = "127.0.0.1";   //51.91.156.75
        private const int SERVER_PORT = 5757;
        private const int SERVER_TIMEOUT = 10_000;

        public static IPAddress getAddress()
        {
            return IPAddress.Parse(SERVER_ADDRESS);
        }
        public static void setAddress(string serverAddress)
        {
            SERVER_ADDRESS = serverAddress;
        }
        public static int getPort()
        {
            return SERVER_PORT;
        }
        public static int getTimeOut()
        {
            return SERVER_TIMEOUT;
        }

    }
}