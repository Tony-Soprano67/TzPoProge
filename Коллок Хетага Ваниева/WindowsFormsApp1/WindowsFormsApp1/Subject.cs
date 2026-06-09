using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Subject
    {
        public string Name { get; set; }
        public string DateTime { get; set; }
        public Subject(string Name, string DateTime)
        {
            this.Name = Name;
            this.DateTime = DateTime;
        }
        
    }
}