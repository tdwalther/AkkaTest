using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Messages
{
    public class StringMessage
    {
        public string Message { get; }

        public StringMessage(string msg)
        {
            Message = msg;
        }
    }
}
