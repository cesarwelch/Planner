using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Planner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //logica de todo

        private void do_some()
        {
            bool[,] aula_tiempo = new bool[9, 280];

            for (int i = 0; i < 9; i++)//Rows
            {
                for (int j = 0; j < 280; j++)//Columns
                {
                    aula_tiempo[i, j] = false;
                    //Console.Write(" "+i+","+j+" ");
                }
                //  Console.WriteLine("\n");
            }


            //Clases Disponibles: 
            List<course> courses = new List<course>();
            /*{



                //file reading
                string[] lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\clases.csv", Encoding.UTF8);



                foreach (string line in lines)
                {

                    //Console.WriteLine("\t" + line);
                    courses.Add(new course(line));

                }
            }*/



            //Filling Teachers
            List<teacher> teachers = new List<teacher>();

            {
                string tempname = "";
                List<string> tempcourses = new List<string>();
                {

                    //file reading
                    Console.WriteLine(Environment.CurrentDirectory + "  hi");
                    string[] lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\maestro por codigo de clase.csv", Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        string[] init = line.Split(',');

                        if (tempname == init[0])
                        {
                            teachers[teachers.Count - 1].add_course(init[1]);
                        }
                        else {

                            int[] k = new int[2] { Int32.Parse(init[2]), Int32.Parse(init[3]) };

                            teachers.Add(new teacher(init[0], k));
                            teachers[teachers.Count - 1].add_course(init[1]);
                            tempname = init[0];
                        }
                    }
                }
            }

            //Alumnos
            List<student> students = new List<student>();

            {

                List<string> tempcourses = new List<string>();
                {

                    //file reading
                    string[] lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\alumno clases.csv", Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        string[] init = line.Split(',');
                        students.Add(new student(Int32.Parse(init[0]), new string[5] { init[1], init[2], init[3], init[4], init[5] }));

                    }

                }
            }


            //Schedule
            for (int i = 0; i < students.Count; i++)
            {
                //  Console.Write("\n" + students[i].id + " ");

                for (int j = 0; j < students[i].courses.Count; j++)
                {
                    bool ban = false;
                    for (int k = 0; k < courses.Count; k++)
                    {
                        // Console.WriteLine(students[i].courses[j]);
                        if (students[i].courses[j] == courses[k].id && courses[k].students.Count < 40)
                        {
                            // Console.WriteLine(courses[k]+"dasd");
                            if (courses[k].hour != students[i].busy.Find(x => x == courses[k].hour))
                            {
                                students[i].busy.Add(courses[k].hour);
                                courses[k].students.Add(students[i].id);
                                ban = true;
                                break;
                            }

                        }
                    }
                    if (ban == false)
                    {
                        for (int k = 0; k < teachers.Count; k++)
                        {
                            if (teachers[k].courses.Contains(students[i].courses[j]) && teachers[k].real_time.Contains(true))
                            {
                                for (int s = 0; s < 9; s++)
                                {
                                    if (teachers[k].real_time[s] == true && !students[i].busy.Contains(s))
                                    {
                                        teachers[k].real_time[s] = false;
                                        courses.Add(new course(students[i].courses[j]));
                                        students[i].busy.Add(s);
                                        courses.Last().students.Add(students[i].id);
                                        courses[courses.Count - 1].le_teacher = teachers[k];
                                        courses.Last().hour = s;
                                        for (int au = 0; au < 280; au++)
                                        {
                                            if (aula_tiempo[s, au] == false)
                                            {
                                                aula_tiempo[s, au] = true;
                                                courses.Last().nclass = au;
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    if (students[i].busy.Contains(s))
                                    {
                                        break;
                                    }
                                }


                                break;
                            }

                        }

                    }
                }

            }
            int sa = 0;
            // maestro y clases
            Console.WriteLine("El horario de clases junto con su maestro y aula");
            textBox1.AppendText("El horario de clases junto con su maestro y aula \n");
            for (int i = 0; i < courses.Count; i++)
            {
                sa += courses[i].students.Count;
                Console.WriteLine(courses[i]);
                textBox1.AppendText(courses[i].ToString() + "\n");
            }
            //prediccion
            Console.WriteLine("Prediccion por Curso");
        
            for (int i = 0; i < courses.Count; i++)
            {
                Console.Write(courses[i].id);
                textBox2.AppendText(courses[i].id);

                sa += courses[i].students.Count;
                for (int j = 0; j < courses[i].students.Count; j++)
                {
                    Console.Write("," + courses[i].students[j]);
                    textBox2.AppendText("," + courses[i].students[j] );
                }
                Console.WriteLine();
                textBox2.AppendText("\n");

            }


            //satisfaccion
            Console.WriteLine("Satisfaccion Promedio de alumno matriculado");
            decimal avg = 0;
            decimal stu = 0;
            for (int i = 0; i < students.Count; i++)
            {
                int calc = 0;
                calc = (students[i].getbusymax() - students[i].getbusymin());
                if (calc < 0)
                {

                    // avg += 0;
                    //     Console.WriteLine(students[i].id + ",N/A");

                }
                else {
                    decimal calc2 = ((decimal)students[i].busy.Count() / (decimal)students[i].courses.Count()) * 3m;
                    int calc3 = (students[i].getbusymax() - students[i].getbusymin());
                    decimal count = 2;
                    for (int k = 0; k < calc3; k++)
                    {
                        count -= 0.22m;
                    }
                    // Console.WriteLine(students[i].id + "," + ((decimal)students[i].busy.Count() / (decimal)students[i].arrcourses.Count()) * 3m + " " + ((decimal)students[i].getbusymax() - (decimal)students[i].getbusymin()) * 0.25m);
                    decimal calc4 = count + calc2;
                    stu++;
                    avg += calc4;
                }


                calc = 0;
            }
            decimal labelsix = avg / stu;
            label6.Text = (labelsix.ToString());
            Console.WriteLine(avg / stu);
        }
        //            List<student> students = new List<student>();
        //            List<teacher> teachers = new List<teacher>();

        //            bool[,] aula_tiempo = new bool[9, 280];
        //            List<course> courses = new List<course>();

        private void button1_Click(object sender, EventArgs e)
        {
            do_some();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
