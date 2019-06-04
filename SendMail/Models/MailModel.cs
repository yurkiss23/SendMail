using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMail.Models
{
    public class MailModel
    {
        public string ReceiverEmail { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
