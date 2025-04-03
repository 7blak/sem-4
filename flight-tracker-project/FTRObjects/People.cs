using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.FTRObjects
{
    public abstract class Person : FTRObject
    {
        public string Name { get; set; }
        public ulong Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Person(string[] _data) : base(_data)
        {
            Name = _data[2];
            Age = ulong.Parse(_data[3]);
            Phone = _data[4];
            Email = _data[5];
        }
    }
    public class Crew : Person
    {
        public ushort Practice { get; set; }
        public string Role { get; set; }
        public Crew(string[] _data) : base(_data)
        {
            Practice = ushort.Parse(_data[6]);
            Role = _data[7];
        }
    }
    public class Passenger : Person
    {
        public string Class { get; set; }
        public ulong Miles { get; set; }
        public Passenger(string[] _data) : base(_data)
        {
            Class = _data[6];
            Miles = ulong.Parse(_data[7]);
        }
    }
}
