using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachers_Record_Project
{
    public class Program
    {
       public static string path = @"D:\Project\Phase1_Assessment\Teachers_Record_Project\TeachersRecord.txt";
        public static void WriteTeacherData()
        {
            
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs) ;
            sw.WriteLine("Teachers Records");
            sw.WriteLine("=====================");
            sw.WriteLine("ID \t Name \t Class \t Section");
            sw.Close();
            fs.Close();

        }
        public static void AppendTeacherData()
        {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs) ;
            try
            {
                Console.WriteLine("Enter Teacher ID:");
                int Id=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Teacher Name:");
                string name=Console.ReadLine();
                Console.WriteLine("Enter Teacher Class: ");
                int Class=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Teacher Section:");
                string Section=Console.ReadLine();
                Teacher t1=new Teacher(Id,name, Class, Section);
                sw.WriteLine("{0}\t{1}\t{2}\t{3}",t1.Id,t1.name,t1.Class,t1.Section);
            }
            catch (IOException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex1) 
            { 
                Console.WriteLine(ex1.Message);
            }
            finally 
            {
                
                sw.Close();
                fs.Close();
            }
        }
        //print record
        public static void ReadTeacherData()
        {
            FileStream fs = new FileStream(path,FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str=sr.ReadLine();
            while (str != null) 
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void UpdateTeacherData(int Id)
        {
            FileStream fs3 = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr3 = new StreamReader(fs3);
            try
            {

                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Class: ");
                int Class = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Section:");
                string Section = Console.ReadLine();
                Teacher t1 = new Teacher(Id,name,Class, Section);
                string updateData = $"{t1.Id}\t{t1.name}\t{t1.Class}\t{t1.Section}";
                string[] lines;
                using (fs3)
                {
                    using (sr3)
                    {
                        lines = File.ReadAllLines(path);
                        for (int i = 2; i < lines.Length; i++)
                        {
                            string[] split = lines[i].Split(',');
                            foreach (var item in split)
                            {
                                if (Char.GetNumericValue(item[0]) == Id)
                                {
                                    lines[i] = updateData;
                                }
                            }
                        }
                        foreach (var item in lines)
                        {
                            Console.WriteLine(item);
                        }

                    }
                }
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in lines)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);// to print input error

            }
        }
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("====== Teacher Records System ======\n\n"+
                    "(1)to enter new data\n"+"(2)to update existing data\n"+
                    "(3) to display teacher records\n"+"(4)to exit\n");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:WriteTeacherData();
                           AppendTeacherData();
                           break;
                    case 2:ReadTeacherData();
                           Console.WriteLine("Enter ID to update:");
                           int Id=Convert.ToInt32(Console.ReadLine());
                           UpdateTeacherData(Id);
                           break;
                    case 3:ReadTeacherData();
                           break;
                    case 4:default: Console.WriteLine("wrong input");
                           break;
                }
                if (choice == 4) { break; }
            }
        }
    }
}
