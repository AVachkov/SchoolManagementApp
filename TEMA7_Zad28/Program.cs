using System;
using System.Collections.Generic;

namespace TEMA7_Zad28
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Натиснете [ENTER] за старт на приложението, или 'q' за край: ");
                string input = Console.ReadLine();
                while (input != "q")
                {
                    Console.Write("Въведете името на училището: ");
                    string schoolName = Console.ReadLine();
                    School school = new School(schoolName);
                    while (input != "q")
                    {
                        Console.Write("За да въведете нов ученик към училището, въведете 's', " +
                            "за нов учител въведете 't', за преглед на информацията за училището 'v': ");
                        string command = Console.ReadLine();
                        switch (command)
                        {
                            case "s":
                            case "S":
                            case "с":
                            case "С":
                                Console.Write("Име на ученик: ");
                                string studentName = Console.ReadLine();
                                Console.Write("Години на ученик: ");
                                if (!Int32.TryParse(Console.ReadLine(), out int studentAge))
                                {
                                    Console.WriteLine("Моля въведете валидна възраст.");
                                    continue;
                                }
                                Console.Write("Клас на ученик(число): ");
                                int grade = int.Parse(Console.ReadLine());
                                Student student = new Student(studentName, studentAge, grade);
                                school.AddStudent(student);
                                Console.WriteLine("Успешно добавихте нов ученик към списъка!");
                                break;
                            case "t":
                            case "T":
                            case "т":
                            case "Т":
                                Console.Write("Име на Учител: ");
                                string teacherName = Console.ReadLine();
                                Console.Write("Години на учител: ");
                                if (!Int32.TryParse(Console.ReadLine(), out int teacherAge))
                                {
                                    Console.WriteLine("Моля въведете валидна възраст.");
                                    continue;
                                }
                                Console.Write("Предмет на учител: ");
                                string subject = Console.ReadLine();
                                Teacher teacher = new Teacher(teacherName, teacherAge, subject);
                                school.AddTeacher(teacher);
                                Console.WriteLine("Успешно добавихте нов учител към списъка!");
                                break;
                            case "v":
                            case "V":
                            case "в":
                            case "В":
                                school.SchoolInfo();
                                break;
                        }
                        Console.WriteLine();
                        Console.Write("Натиснете [ENTER] за да продължите, или 'q' за край: ");
                        input = Console.ReadLine();
                    }
                    Console.Write("Въведете отново името на училището преди изход: ");
                    schoolName = Console.ReadLine();
                    Console.WriteLine($"Училище: {schoolName} приключи.");
                }
                Console.WriteLine("Край!");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred" + e.Message);
            }
        }
    }
    class Person
    {
        string name;
        int age;
        public string Name
        {
            get { return this.name; }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                age = value;
            }
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Име: {Name}, Възраст: {Age} години";
        }
    }
    class Student : Person
    {
        int grade;
        public int Grade
        {
            get { return this.grade; }
            set
            {
                grade = value;
            }
        }
        public Student(string name, int age, int grade) : base(name, age)
        {
            Grade = grade;
        }
        public override string ToString()
        {
            return $"Ученик: {Name}, Възраст: {Age} години, Клас: {Grade}";
        }
    }
    class Teacher : Person
    {
        string subject;
        public string Subject
        {
            get { return this.subject; }
            set
            {
                subject = value;
            }
        }
        public Teacher(string name, int age, string subject) : base(name, age)
        {
            Subject = subject;
        }
        public override string ToString()
        {
            return $"Учител: {Name}, Възраст: {Age} години, Предмет: {Subject}";
        }
    }
    class School
    {
        string name;
        List<Student> students;
        List<Teacher> teachers;
        public string Name
        {
            get { return this.name; }
            set
            {
                name = value;
            }
        }
        public List<Student> Students
        {
            get { return this.students; }
            set
            {
                students = value;
            }
        }
        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set
            {
                teachers = value;
            }
        }
        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        public void SchoolInfo()
        {
            Console.WriteLine($"Училище: {Name}");
            if (Students.Count > 0)
            {
                Console.WriteLine("Ученици:");
                Console.WriteLine(String.Join('\n', Students));
            }
            else
                Console.WriteLine("Няма добавени ученици.");

            if (Teachers.Count > 0)
            {
                Console.WriteLine("Учители:");
                Console.WriteLine(String.Join('\n', Teachers));
            }
            else
                Console.WriteLine("Няма добавени учители.");
        }
    }
}
