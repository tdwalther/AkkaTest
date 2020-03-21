using PortableMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2.viewmodels
{
    public class GameVM : ViewModelBase
    {
        private int _GameID;
        private int _Inning;
        private string _IsGameOver;
        private string _TopOrBottom;
        private string _PlayResult;

        private string _Out1;
        private string _Out2;

        private string _HomeTeam;
        private int _HomeRuns;
        private int _HomeHits;
        private int _HomeErrors;

        private string _AwayTeam;
        private int _AwayRuns;
        private int _AwayHits;
        private int _AwayErrors;

        private string _RunnerOnFirst;
        private string _RunnerOnSecond;
        private string _RunnerOnThird;

        private string _Strike1;
        private string _Strike2;

        private string _Ball1;
        private string _Ball2;
        private string _Ball3;

        #region observable properties

        public string RunnerOnFirst
        {
            get
            {
                return _RunnerOnFirst;
            }

            set
            {
                _RunnerOnFirst = value; OnPropertyChanged("RunnerOnFirst");
            }
        }

        public string RunnerOnSecond
        {
            get
            {
                return _RunnerOnSecond;
            }

            set
            {
                _RunnerOnSecond = value; OnPropertyChanged("RunnerOnSecond");
            }
        }

        public string RunnerOnThird
        {
            get
            {
                return _RunnerOnThird;
            }

            set
            {
                _RunnerOnThird = value; OnPropertyChanged("RunnerOnThird");
            }
        }

        public string Strike1
        {
            get
            {
                return _Strike1;
            }

            set
            {
                _Strike1 = value; OnPropertyChanged("Strike1");
            }
        }

        public string Strike2
        {
            get
            {
                return _Strike2;
            }

            set
            {
                _Strike2 = value; OnPropertyChanged("Strike2");
            }
        }

        public string Ball1
        {
            get
            {
                return _Ball1;
            }

            set
            {
                _Ball1 = value; OnPropertyChanged("Ball1");
            }
        }

        public string Ball2
        {
            get
            {
                return _Ball2;
            }

            set
            {
                _Ball2 = value; OnPropertyChanged("Ball2");
            }
        }

        public string Ball3
        {
            get
            {
                return _Ball3;
            }

            set
            {
                _Ball3 = value; OnPropertyChanged("Ball3");
            }
        }

        public string HomeTeam
        {
            get
            {
                return _HomeTeam;
            }

            set
            {
                _HomeTeam = value; OnPropertyChanged("HomeTeam");
            }
        }

        public int HomeRuns
        {
            get
            {
                return _HomeRuns;
            }

            set
            {
                _HomeRuns = value; OnPropertyChanged("HomeRuns");
            }
        }

        public int HomeHits
        {
            get
            {
                return _HomeHits;
            }

            set
            {
                _HomeHits = value; OnPropertyChanged("HomeHits");
            }
        }

        public int HomeErrors
        {
            get
            {
                return _HomeErrors;
            }

            set
            {
                _HomeErrors = value; OnPropertyChanged("HomeErrors");
            }
        }

        public string AwayTeam
        {
            get
            {
                return _AwayTeam;
            }

            set
            {
                _AwayTeam = value; OnPropertyChanged("AwayTeam");
            }
        }

        public int AwayRuns
        {
            get
            {
                return _AwayRuns;
            }

            set
            {
                _AwayRuns = value; OnPropertyChanged("AwayRuns");
            }
        }

        public int AwayHits
        {
            get
            {
                return _AwayHits;
            }

            set
            {
                _AwayHits = value; OnPropertyChanged("AwayHits");
            }
        }

        public int AwayErrors
        {
            get
            {
                return _AwayErrors;
            }

            set
            {
                _AwayErrors = value; OnPropertyChanged("AwayErrors");
            }
        }

        public int Inning
        {
            get
            {
                return _Inning;
            }

            set
            {
                _Inning = value; OnPropertyChanged("Inning");
            }
        }

        public string TopOrBottom
        {
            get
            {
                return _TopOrBottom;
            }

            set
            {
                _TopOrBottom = value; OnPropertyChanged("TopOrBottom");
            }
        }

        public string PlayResult
        {
            get
            {
                return _PlayResult;
            }

            set
            {
                _PlayResult = value; OnPropertyChanged("PlayResult");
            }
        }

        public string Out1
        {
            get
            {
                return _Out1;
            }

            set
            {
                _Out1 = value; OnPropertyChanged("Out1");
            }
        }

        public string Out2
        {
            get
            {
                return _Out2; 
            }

            set
            {
                _Out2 = value; OnPropertyChanged("Out2");
            }
        }

        public int GameID
        {
            get
            {
                return _GameID;
            }

            set
            {
                _GameID = value;
                OnPropertyChanged("GameID");
            }
        }

        public string IsGameOver
        {
            get
            {
                return _IsGameOver;
            }

            set
            {
                _IsGameOver = value;
                OnPropertyChanged("IsGameOver");
            }
        }

        #endregion
    }
}
