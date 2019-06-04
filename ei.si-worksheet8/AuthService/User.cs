using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuthService
{
    [DataContract] //se o WCF precisar de usar esta classe, vai intrepretar isto que vem a seguir
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Role { get; set; }
        //não vai passar a password
        public string Password { get; set; }



    }
}