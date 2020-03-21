using Akka.Actor;
using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibrary2.Actors
{
    public class GameActor : ReceiveActor
    {
        public static Props Create(IGame gm)
        {
            return Props.Create(() => new GameActor(gm));
        }

        private readonly IGame _igm;

        public GameActor(IGame gm)
        {
            _igm = gm;

            _igm.Alert += m => Context.ActorSelection("/user/recorder").Tell(new Messages.StringMessage(m));

            Receive<Messages.StringMessage>(msg =>
            {
                _igm.PlayGame(msg.Message);        
            });
        }
    }
}
