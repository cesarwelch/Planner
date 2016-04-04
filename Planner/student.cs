using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    class student
    {
        public int id { get; set; }
        public string [] arrcourses { get; set; }

        public List<string> courses = new List<string>();
        
        public List<int> busy = new List<int>();
        
        

        public void del_rep() {
            for (int i = 0; i < courses.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                {
                    if (courses[i]==courses[j]&& i!=j)
                    {
                        courses.Remove(courses[j]);

                    }


                }
            }
        }


        public student(int id, string[] arrcourses)
        {
            this.id = id;
            this.arrcourses = arrcourses;
            for (int i = 0; i < 5; i++)
            {
                if (arrcourses[i]!= "")
                {
                    courses.Add(arrcourses[i]);
                }
            }

            del_rep();
        }
        public student(int id)
        {
            this.id = id;
            this.arrcourses = null;
        }
        /*
        public override string ToString()
        {
            string retval = id + ""  ; 
            for (int i = 0; i < arrcourses.Length; i++)
            {
                retval += ","+arrcourses[i];
            }

            for (int i = 0; i < 5-arrcourses.Length; i++)
            {
                retval += ",";

            }

            return retval;
        }*/
        public override string ToString()
        {
            string retval = id + "";
            for (int i = 0; i < arrcourses.Length; i++)
            {
                retval += "," + arrcourses[i];
            }
            /*
            for (int i = 0; i < 5 - arrcourses.Length; i++)
            {
                retval += ",";

            }*/
            for (int i = 0; i < busy.Count; i++)
            {
                retval += " " +busy[i];

            }

            return retval;
        }

        public int getbusymin() {
            int min=8;
            for (int i = 0; i < busy.Count; i++)
            {
                if (min > busy[i]) {
                    min = busy[i];
                }
            }
            return min;
        }
        public int getbusymax()
        {
            int min = 0;
            for (int i = 0; i < busy.Count; i++)
            {
                if (min < busy[i])
                {
                    min = busy[i];
                }
            }
            return min;
        }


    }
}
