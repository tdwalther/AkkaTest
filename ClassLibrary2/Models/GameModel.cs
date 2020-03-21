using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Models
{
    public delegate void AlertDelegate(string alrt);
    public interface IGame
    {
        AlertDelegate Alert { get; set; }
        void PlayGame(string msg);
    }

    public class GameModel : IGame
    {
        public int GameID { get; set; }
        public bool IsGameOver { get; set; }
        public AlertDelegate Alert { get; set; }
        public void PlayGame(string msg)
        {
            int HmHits = 0;
            int HmErr = 0;
            int AwHits = 0;
            int AwErr = 0;

            var splitmsg = msg.Split(",".ToCharArray());
            GameID = Convert.ToInt16(splitmsg[0]);
            using (var fs = System.IO.File.OpenText(splitmsg[1]))
            {
                while (!fs.EndOfStream)
                {
                    var line = fs.ReadLine();
                    string[] parsed = line.ToString().Split(",".ToCharArray());

                    if (parsed[0] == "GameId") continue;

                    StringBuilder sb = new StringBuilder();

                    sb.Append("{");

                    sb.Append($"GameID: {GameID}, ");

                    sb.Append($"IsGameOver: {parsed[79]}, ");

                    var outs = parsed[4];
                    switch (outs)
                    {
                        case "1":
                            sb.Append("Out1: \"Yellow\", ");
                            sb.Append("Out2: \"LightGreen\", ");
                            break;
                        case "2":
                            sb.Append("Out1: \"Yellow\", ");
                            sb.Append("Out2: \"Yellow\", ");
                            break;
                        default:
                            sb.Append("Out1: \"LightGreen\", ");
                            sb.Append("Out2: \"LightGreen\", ");
                            break;
                    }

                    var ro1 = String.IsNullOrEmpty(parsed[26]) || parsed[26] == "\"\"" ? "LightGreen" : "Yellow";
                    var ro2 = String.IsNullOrEmpty(parsed[27]) || parsed[27] == "\"\"" ? "LightGreen" : "Yellow";
                    var ro3 = String.IsNullOrEmpty(parsed[28]) || parsed[28] == "\"\"" ? "LightGreen" : "Yellow";

                    sb.Append($"RunnerOnFirst: \"{ro1}\", ");
                    sb.Append($"RunnerOnSecond: \"{ro2}\", ");
                    sb.Append($"RunnerOnThird: \"{ro3}\", ");

                    var tob = parsed[3] == "0" ? "Top" : "Bottom";

                    sb.Append($"Inning: {parsed[2]}, ");
                    sb.Append($"TopOrBottom: \"{tob}\", ");
                    sb.Append($"PlayResult: \"\", ");

                    var hmtm = parsed[0].Substring(1, 3);

                    sb.Append($"AwayTeam: {parsed[1]}, ");
                    sb.Append($"AwayRuns: {parsed[8]}, ");
                    sb.Append($"AwayHits: {AwHits}, ");
                    sb.Append($"AwayErrors: {AwErr}, ");

                    sb.Append($"HomeTeam: \"{hmtm}\", ");
                    sb.Append($"HomeRuns: {parsed[9]}, ");
                    sb.Append($"HomeHits: {HmHits}, ");
                    sb.Append($"HomeErrors: {HmErr}, ");

                    sb.Append($"Strike1: \"LightGreen\", ");
                    sb.Append($"Strike2: \"LightGreen\", ");

                    sb.Append($"Ball1: \"LightGreen\", ");
                    sb.Append($"Ball2: \"LightGreen\", ");
                    sb.Append($"Ball3: \"LightGreen\" ");

                    sb.Append("}");

                    System.Threading.Thread.Sleep(Convert.ToInt16(50 + 5 * RandomObjects.RandomNumbers.GetRandomNumberInstance().GetDouble()));
                    
                    if (Alert != null)
                    {
                        Alert(sb.ToString());
                    }
                }
            }
        }
    }
}
