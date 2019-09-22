using System;
using System.Net;

namespace Application.Client.Entities.Message
{
    class Client
    {
        // The ip address is not in the database,
        // this is the current position of the client when he log on
        public IPAddress idAddress { get; set; }


        // This informations are get from the API 
        // when a user try to send to the server his credentials
        public int idUser { get; set; }
        public int idAccount { get; set; }
        public string nicknameUser { get; set; }
        public string firstNameUser { get; set; }
        public string lastNameUser { get; set; }
        public DateTime birthdayUser { get; set; }
        public string genderUser { get; set; }
        public string statusUser { get; set; }


        // The client constructor
        public Client(
            int idUser,
            int idAccount,
            string nicknameUser,
            string firstNameUser,
            string lastNameUser,
            DateTime birthdayUser,
            string genderUser,
            string statusUser
            )
        {
            this.idUser = idUser;
            this.idAccount = idAccount;
            this.nicknameUser = nicknameUser;
            this.firstNameUser = firstNameUser;
            this.lastNameUser = lastNameUser;
            this.birthdayUser = birthdayUser;
            this.genderUser = genderUser;
            this.statusUser = statusUser;
        }


        // get the token of the client 
        // Nickname#012345
        public string getToken()
        {
            return this.nicknameUser + "#" + this.idAccount;
        }
    }
}
