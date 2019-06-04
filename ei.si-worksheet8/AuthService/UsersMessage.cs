using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuthService
{
    [DataContract]
    public class UsersMessage : BaseMessage
    {
        [DataMember]
        public User[] Users { get; set; }
    }
}