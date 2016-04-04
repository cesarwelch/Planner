using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    class course
    {
        public string id { get; set; }
        public List<int> students { get; set; } 
        public teacher le_teacher { get; set; }
        public int hour { get; set; }
        public int nclass { get; set; } //aula


        public course(string id, teacher le_teacher, int hour, int nclass)
        {
            this.id = id;
            this.le_teacher = le_teacher;
            this.hour = hour;
            this.nclass = nclass;
            this.students = new List<int>();
        }

        public course(string id)
        {
            this.id = id;
          
            this.le_teacher = null;
            this.hour = -1;
            this.nclass = -1;
            this.students = new List<int>();

        }
        /*
                public override string ToString()
                {
                    return "course: " + id + " " + students +" "+ le_teacher + " " + hour + " " + nclass;
                }

            */

        public override string ToString()
        {
            string s = "" ;
            switch (hour)
            {

                case 0:
                    s+="7:00 AM,";
                    break;
                case 1:
                    s += "8:30 AM,";
                    break;
                case 2:
                    s += "10:10 AM,";
                    break;
                case 3:
                    s += "11:30 AM,";
                    break;
                case 4:
                    s += "1:00 PM,";
                    break;
                case 5:
                    s += "2:20 PM,";
                    break;
                case 6:
                    s += "3:40 PM,";
                    break;
                case 7:
                    s += "5:10 PM,";
                    break;
                case 8:
                    s += "6:30 PM,";
                    break;

                default:
                    //Console.WriteLine("Default case");
                    break;

            }
            s += id + "," + le_teacher.id + "," + nclass;
            return  s;
        }
    }
}
