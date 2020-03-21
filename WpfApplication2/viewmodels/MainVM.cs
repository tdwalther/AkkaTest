using Akka.Actor;
using ClassLibrary2.Actors;
using ClassLibrary2.Models;
using ClassLibrary2.Messages;
using PortableMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.IO;

namespace WpfApplication2.viewmodels
{
    public class MainVM : ViewModelBase
    {
        private ObservableCollection<GameVM> _Games;

        private ObservableCollection<string> _Messages;

        private string _Title;

        public ObservableCollection<string> Messages
        {
            get
            {
                return _Messages;
            }

            set
            {
                _Messages = value; OnPropertyChanged("Messages");
            }
        }

        public ICommand StartupCmd { get; set; }

        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value; OnPropertyChanged("Title");
            }
        }

        public ObservableCollection<GameVM> Games
        {
            get
            {
                return _Games;
            }

            set
            {
                _Games = value; OnPropertyChanged("Games");
            }
        }

        private ActorSystem system;
        IActorRef super, recer;
        private string GamePath = Path.Combine(Environment.CurrentDirectory, "data");

        private string[] GameFiles;

        private int GamesPlayed = 1;

        public MainVM()
        {
            Games = new ObservableCollection<GameVM>();
            Messages = new ObservableCollection<string>();
            StartupCmd = new RelayCommand(OnStartUpCmd);
            MainSupModel sup = new MainSupModel();
            RecordingModel rec = new RecordingModel();

            system = ActorSystem.Create("helloAkka");
            super = system.ActorOf(MainSupervisor.Create(sup), "supervisor");
            recer = system.ActorOf(RecordingActor.Create(rec), "recorder");

            int phlwins = 0;
            int phllosses = 0;

            GameFiles = System.IO.Directory.GetFiles(GamePath).Where(f => f.Contains(".csv")).ToArray();

            rec.OnRecord += (m =>
            {
                
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        try
                        {
                            var gm = Newtonsoft.Json.JsonConvert.DeserializeObject<GameVM>(m);

                            if( gm.IsGameOver == "T" && (gm.HomeTeam == "PHI" || gm.AwayTeam == "PHI"))
                            {
                                if( (gm.HomeTeam == "PHI" && gm.HomeRuns > gm.AwayRuns) || (gm.AwayTeam == "PHI" && gm.AwayRuns > gm.HomeRuns))
                                {
                                    phlwins++;
                                }
                                else
                                {
                                    phllosses++;
                                }
                                Messages.Add($"{GamesPlayed++, 3} {gm.HomeTeam, -4} {gm.HomeRuns, 2}  {gm.AwayTeam, -4} {gm.AwayRuns, 2}  {phlwins,3} - {phllosses, -3}");
                            }

                            var gamevm = Games.FirstOrDefault(g => g.GameID == gm.GameID);
                            if( gamevm == null)
                            {
                                Games.Add(gm);
                            }
                            else
                            {
                                var gm1 = Games.First(g => g.GameID == gm.GameID);
                                gm1.Inning = gm.Inning;
                                gm1.AwayTeam = gm.AwayTeam;
                                gm1.AwayRuns = gm.AwayRuns;
                                gm1.HomeTeam = gm.HomeTeam;
                                gm1.HomeRuns = gm.HomeRuns;
                                gm1.Out1 = gm.Out1;
                                gm1.Out2 = gm.Out2;                                
                                gm1.RunnerOnFirst = gm.RunnerOnFirst;
                                gm1.RunnerOnSecond = gm.RunnerOnSecond;
                                gm1.RunnerOnThird = gm.RunnerOnThird;
                                gm1.Strike1 = gm.Strike1;
                                gm1.Strike2 = gm.Strike2;
                                gm1.Ball1 = gm.Ball1;
                                gm1.Ball2 = gm.Ball2;
                                gm1.Ball3 = gm.Ball3;
                            }                                                                                   
                        }
                        catch (Exception ex)
                        {
                            //Messages.Add(m);
                        }
                    }));
            });
        }

        private void OnStartUpCmd(object o)
        {
            for (int i = 0; i < GameFiles.Count(); i++)
            {
                super.Tell(new StringMessage($"{i},{GameFiles[i]}"));
                
            }
        }
    }
}
