using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachers_Record_Project
{
    public class Teacher
    {
       public int Id;
       public string name;
      public  int Class;
       public string Section;
        public  Teacher(int Id, string name, int Class,string Section)
        {
            this.Id = Id;
            this.name = name;
            this.Class = Class;
            this.Section = Section;
        }
    }
}
