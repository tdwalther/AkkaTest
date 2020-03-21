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
    public class MainSupervisor : ReceiveActor
    {
        public static Props Create(IMain mainsup)
        {
            return Props.Create(() => new MainSupervisor(mainsup));
        }

        private readonly IMain _imainsup;
        private List<IActorRef> _GmActors = new List<IActorRef>();

        public MainSupervisor(IMain mainsup)
        {
            int childindex = 0;
            _imainsup = mainsup;

            Receive<StringMessage>(msg =>
            {
                System.Threading.Thread.Sleep(1000);
                Context.ActorSelection("/user/recorder").Tell(new Messages.StringMessage($"{Self.Path} received  {msg.Message}"));
                _GmActors.Add(Context.ActorOf(GameActor.Create(new GameModel() { GameID = childindex }), $"GM{childindex++}"));
                _GmActors.Last().Tell(msg);
            });

            #region old code
            //Receive<StringMessage>(msg =>
            //{
            //    Context.ActorSelection("/user/recorder").Tell(new Messages.StringMessage($"{Self.Path} received  {msg.Message}"));
            //    _imainsup.Alert($"main supervisor received  {msg.Message}");
            //    StringMessage gmPath = new StringMessage(@"C:\code\PhillyCodeCamp2016\Data\PHI2015.CSV");
            //    _GmActors.Add(Context.ActorOf(GameActor.Create(new GameModel()), $"GM{childindex++}"));
            //    _GmActors.Last().Tell(gmPath);
            //    gmPath = new StringMessage(@"C:\code\PhillyCodeCamp2016\Data\PIT2015.CSV");
            //    _GmActors.Add(Context.ActorOf(GameActor.Create(new GameModel()), $"GM{childindex++}"));
            //    _GmActors.Last().Tell(gmPath);
            //});
            #endregion
        }
    }
}
