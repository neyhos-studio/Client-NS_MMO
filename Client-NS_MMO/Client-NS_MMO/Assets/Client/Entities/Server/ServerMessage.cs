using System;

namespace Application.Client.Entities.Server
{
    class ServerMessage
    {
        public string id { get; }
        public string action { get; }
        public string[] data { get; }


        public ServerMessage(string clientMessage)
        {
            string[] message_index;
            try
            {
                message_index = clientMessage.Split('|');

                this.id = message_index[0];
                this.action = message_index[1];
                this.data = message_index[2].Split(';');

            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }
    }
}
