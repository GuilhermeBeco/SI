using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuthService
{
    [DataContract]
    public class BaseMessage
    {
        //public string status;   //isto é um fill
        [DataMember]
        public string Status { get; set; }    //isto é uma property
        [DataMember]
        public string Message { get; set; }
    }
}