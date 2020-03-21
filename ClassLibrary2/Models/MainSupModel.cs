using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka;
using Akka.Actor;
using Akka.Event;
using Akka.Routing;
using Akka.Configuration;
using Akka.Dispatch;
using Akka.IO;
using Akka.Pattern;
using Akka.Serialization;
using Akka.Tools;
using Akka.Util;

namespace ClassLibrary2.Models
{
    public interface IMain
    {
        void Alert(string msg);
    }

    public class MainSupModel : IMain
    {
        
        public void Alert(string msg)
        {
            
            
        }
    }
}
