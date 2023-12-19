using System.Collections.Generic;

namespace RegistrationAPI.Models
{
    public class ResponseMessage
    {
        public string errorCode { get; set; }
        public string errorDesc { get; set; }
        public List<object> data { get; set; }
    }
}