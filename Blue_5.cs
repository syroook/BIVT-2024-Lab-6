using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (_place == 0 && place >= 1)
                    _place = place;
            }
            public void Print()
            {
                Console.WriteLine($"{_name}\t{_surname}\t{_place}");
            }
        }


        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int summaryScore = 0;
                    foreach (Sportsman sportsman in _sportsmen)
                    {
                        if (sportsman.Place == 1) summaryScore += 5;
                        else if (sportsman.Place == 2) summaryScore += 4;
                        else if (sportsman.Place == 3) summaryScore += 3;
                        else if (sportsman.Place == 4) summaryScore += 2;
                        else if (sportsman.Place == 5) summaryScore += 1;
                        else break;
                    }   
                    return summaryScore;
                }
            }
            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int topPlace = 18;
                    foreach (Sportsman sportsman in _sportsmen)
                    {
                        if(topPlace >  sportsman.Place)
                            topPlace = sportsman.Place;
                    }
                    return topPlace;
                }
            }
            //труктор
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null || _count == 6) return;
                _sportsmen[_count++] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null) return;
                foreach (Sportsman sportsman in sportsmen)
                    Add(sportsman);
            }
            public static void Sort(Team[] teams)
            {
                if (teams == null) return;
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            var temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace)
                        {
                            var temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name}: ");
                foreach (Sportsman sportsman in _sportsmen)
                    sportsman.Print();
                Console.WriteLine("");
            }
        }
    }
}
