using Akka.Actor;
using ClassLibrary2.Messages;
using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Actors
{
    public class RecordingActor : ReceiveActor
    {
        public static Props Create(IRecording rec)
        {
            return Props.Create(() => new RecordingActor(rec));
        }

        private readonly IRecording _irecord;

        public RecordingActor(IRecording rec)
        {
            _irecord = rec;

            Receive<StringMessage>(msg =>
            {                
                _irecord.Record($"{msg.Message}");
            });
        }

    }
}
