using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Models
{
    public interface IRecording
    {
        void Record(string msg);

    }

    public delegate void RecordDelegate(string msg);

    public class RecordingModel : IRecording
    {
        public RecordDelegate OnRecord { get; set; }

        public void Record(string msg)
        {
            if (OnRecord != null) OnRecord(msg);
        }

         
    }
}
