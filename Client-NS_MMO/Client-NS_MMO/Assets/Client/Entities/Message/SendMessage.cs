﻿using System;

namespace Application.Client.Entities.Message
{
    class SendMessage
    {
        public string id { get; }
        public string action { get; }
        public string[] data { get; }

        public SendMessage() { }


        public SendMessage(string id, string action, string[] data)
        {
            this.id = id;
            this.action = action;
            this.data = data;
        }

        public string getMessage()
        {
            string datasToString = String.Empty;
            int i = 1;
            foreach (string d in this.data)
            {
                datasToString += d;

                if (i != this.data.Length)
                {
                    datasToString += ";";
                }
                i++;
            }
            return String.Format("{0}|{1}|{2}", this.id, this.action, datasToString);
        }


    }
}
