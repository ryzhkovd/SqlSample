using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Phone> phones { get; set; }
        public string position { get; set; }
        public User()
        {
            phones = new List<Phone>();
        }
    }
}
