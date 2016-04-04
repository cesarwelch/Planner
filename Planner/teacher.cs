using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    class teacher
    {
        public String id { get; set; }
        public List<string> courses = new List<string>();
        public int [] avail_time { get; set; }
        public bool[] real_time { get; set; }

        public void add_course(string course) {
       
            this.courses.Add(course);
        }
        public teacher(string id, int[] avail_time)
        {
            this.id = id;

            this.avail_time = avail_time;
            this.real_time = new bool[9] { false, false, false, false, false, false, false, false, false }; ;

            for (int i = avail_time[0]-1; i < avail_time[1]; i++)
            {
                real_time[i] = true;
                
            }

        }

        public override string ToString()
        {
            string retval = id + " Courses: ";

            for (int i = 0; i < courses.Count; i++)
            {
                retval += "," + courses[i];
            }

            retval += " Horario:  ";

            for (int i = 0; i < real_time.Length; i++)
            {
                retval += " " +real_time[i];

            }

            return retval;
        }



    }
}
