using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;
            //private bool _isExpelled;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null) return default(int[]);
                    var penaltyTimes = new int[_penaltyTimes.Length];
                    Array.Copy(_penaltyTimes, penaltyTimes, _penaltyTimes.Length);
                    return penaltyTimes;
                } 
            }
            public int TotalTime => _penaltyTimes.Sum();
            public bool IsExpelled
            {
                get
                {
                    if(_penaltyTimes == null) return true; //нет больше 10
                    foreach(int i in _penaltyTimes)
                    {
                        if (i == 10) return false;
                    }
                    return true;
                }
            }
            //конструктор
            public Participant(string name, string surname)
            {
                _name =name;
                _surname =surname;
                _penaltyTimes = new int[0]; //не знаем размер(кол-во матчей)

            }
            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null) return;
                var newArray = new int[_penaltyTimes.Length+1];
                Array.Copy(_penaltyTimes, newArray, _penaltyTimes.Length);
                newArray[_penaltyTimes.Length] = time;
                _penaltyTimes = newArray;
            }
            public static void Sort(Participant[] array)//12345
            {
                if(array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length-1-i; j++)
                    {
                        if (array[j].TotalTime > array[j+1].TotalTime)
                        {
                            var temp = array[j]; 
                            array[j] = array[j+1];
                            array[j+1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name}\t{Surname}");
                foreach (var item in _penaltyTimes) Console.Write(item + " ");
                Console.WriteLine();
                Console.WriteLine($"Total time: {TotalTime} - {this.IsExpelled}");

            }

        }
    }
}
