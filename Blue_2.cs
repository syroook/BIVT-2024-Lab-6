using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;

            //свойства для чтения приватных полей
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return default(int[,]);
                    var newArray = new int[2, 5];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            newArray[i,j] = _marks[i, j];
                        }
                    }
                    return newArray;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0; //zero прягнул чел упал лицом в грязь
                    int totalScore = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            totalScore += _marks[i, j];
                        }
                    }
                    return totalScore;
                }  
            }

            //конструктор(тоже является методом)
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2,5]; //не null тк из условия ограниченое число
            }
            //метод
            public void Jump(int[] result) //заполнение оценками массива _marks
            {
                bool isFirstJumpFilled = _marks[0, 0] != 0 || _marks[0, 1] != 0 
                    || _marks[0, 2] != 0 || _marks[0, 3] != 0 || _marks[0, 4] != 0;
                
                if(!isFirstJumpFilled)
                {
                    for (int j = 0; j < 5; j++)
                        _marks[0, j] = result[j];
                }
                //заполнен ли второй прыжок
                else if (!(_marks[1, 0] != 0 || _marks[1, 1] != 0 || _marks[1, 2] != 0 || _marks[1, 3] != 0 || _marks[1, 4] != 0))
                {
                    for (int j = 0; j < 5; j++)
                        _marks[1, j] = result[j];
                }

                //int firstJump = 0, secondJump = 0;
                //if (firstJump == 0 && secondJump== 0)
                //{
                //    for (int j = 0; j < 5; j++)
                //    {
                //        _marks[0,j] = result[j];
                //        firstJump += result[j];
                //    }
                //}
                //else if (firstJump != 0 &&  secondJump == 0)
                //{
                //    for (int j = 0; j < 5; j++)
                //    {
                //        _marks[1, j] = result[j];
                //        secondJump += result[j];
                //    }
                //}
            }
            public static void Sort(Participant[] array) //54321
            {
                if (array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length - i; j++)
                    {
                        if (array[j-1].TotalScore < array[j].TotalScore)
                        {
                            var temp = array[j - 1];
                            array[j - 1] = array[j];
                            array[j] = temp;

                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name}\t{Surname}");
                for(int i = 0; i < _marks.GetLength(0); i++)
                {
                    for(int j = 0; j < _marks.GetLength(1); j++)
                    {
                        Console.Write(_marks[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }




        }
        

    }
}
