using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            //приватные поля
            private string _name;
            private string _surname;
            private int _vote;

            //свойства для чтения приватных полей
            public string Name => _name;
            public string Surname => _surname;
            public int Vote => _vote;
            
            //конструктор
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _vote = 0;
            }
            //метод
            public int CountVotes(Response[] responses)
            {
                if (responses == null ) return 0;
                int result = 0;
                foreach (var response in responses)
                {
                    if (response.Name ==_name && response.Surname == _surname)
                    {
                        result++;
                    }
                }

                _vote = result;
                return result;
            }
            public void Print()
            {
                Console.WriteLine($"{Name}\t{Surname}\t{Vote}");
            }


        }

    }
}
