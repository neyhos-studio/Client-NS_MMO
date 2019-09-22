using System.Net;

namespace Application.Client.Entities.Authentication
{
    class Credentials
    {
        public string email { get; set; }
        public string password { get; set; }
        public IPAddress ip { get; set; }

        public Credentials(string email, string password, IPAddress ip)
        {
            this.email = email;
            this.password = password;
            this.ip = ip;
        }

        public void purge()
        {
            this.email = null;
            this.password = null;
        }

        override public string ToString()
        {
            return "{  " +
                "\"email\": \"" + this.email + "\",  " +
                "\"password\": \"" + this.password + "\", " +
                "\"ip\": \"" + this.ip.ToString() + "\" " +
                "}";
        }
    }
}
