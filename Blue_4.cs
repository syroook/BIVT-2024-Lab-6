using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return default(int[]);
                    var newArray = new int[_scores.Length];
                    Array.Copy(_scores, newArray, _scores.Length);
                    return newArray;
                }
            }
            public int TotalScore => _scores.Sum();

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }
            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                var newArray = new int[_scores.Length+1];
                Array.Copy(_scores, newArray,_scores.Length);
                newArray[_scores.Length] = result;
                _scores = newArray;
            }
            public void Print()
            {
                Console.WriteLine($"{Name}\t {TotalScore}");
            }

            public struct Group
            {
                private string _name;
                private Team[] _team;
                private int _count;

                public string Name => _name;
                public Team[] Team => _team;

                public Group(string name)
                {
                    _name = name;
                    _team = new Team[12]; //group<=12
                    _count = 0;
                }

                public void Add(Team team)
                {
                    if (_team == null || _count >= 12) return;
                    _team[_count++] = team;
                }
                public void Sort()//54321
                {
                    if ( _team == null ) return;
                    for (int i = 0; i < _team.Length; i++)
                    {
                        for (int j = 0; j < _team.Length-1-i; j++)
                        {
                            if (_team[j].TotalScore < _team[j+1].TotalScore)
                            {
                                var temp = _team[j];
                                _team[j] = _team[j+1];
                                _team[j+1] = temp;
                            }
                        }
                    }
                }
                public static Group Merge(Group group1, Group group2, int size)
                {
                    if (size < -1) return default(Group);
                    Group newArray = new Group("Финалисты");
                    int i = 0;
                    int j = 0;
                    while (i < size/2 && j < size/2)
                    {
                        if (group1.Team[i].TotalScore >= group2.Team[j].TotalScore) 
                            newArray.Add(group1.Team[i++]);
                        else
                            newArray.Add(group2.Team[i++]);
                    } 
                    while (i < size/2 ) newArray.Add(group1.Team[i++]);
                    while (j < size/2) newArray.Add(group2.Team[j++]);
                    return newArray;
                }
                public void Print()
                {
                    Console.WriteLine(Name);
                    foreach(var i in _team) Console.Write(i + " ");
                    Console.WriteLine();
                }






            }


        }
    }
}
