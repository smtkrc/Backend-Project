using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralClass.Utilities.Security.JeasonWebToken
{
    public class AccessToken
    {
        //Token Adı
        public string Token { get; set; }
        //Bitiş zamanı
        public DateTime Expiration { get; set; }
    }
}
