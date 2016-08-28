using System;

namespace lab3
{
    abstract class Stud
    {
        private string _surname, _faculty;
        private DateTime _birthday;

        protected Stud(string surname, DateTime birthday, string faculty)
        {
            this._surname = surname;
            this._birthday = birthday;
            this._faculty = faculty;
        }

        public void Print()
        {
            Console.Write("Surname: {0}; Birthday: {1}; Faculty: {2}", _surname, _birthday.ToShortDateString(), _faculty);
        }

        public int Age()
        {
            return _birthday.DayOfYear < DateTime.Now.DayOfYear ? DateTime.Now.Year - _birthday.Year : DateTime.Now.Year - _birthday.Year - 1;
        }
    }

    class Enrollee : Stud
    {
        public Enrollee(string surname, DateTime birthday, string faculty) : base(surname, birthday, faculty) { }

        new public void Print()
        {
            Console.Write("Enrollee; ");
            base.Print();
            Console.WriteLine();
        }
    }

    class Student : Stud
    {
        private int _course;

        public Student(string surname, DateTime birthday, string faculty, int course)
            : base(surname, birthday, faculty)
        {
            this._course = course;
        }

        new public void Print()
        {
            Console.Write("Student;  ");
            base.Print();
            Console.WriteLine("; Course: {0}", _course);
        }
    }

    class Teacher : Stud
    {
        private string _post;
        private int _experience;

        public Teacher(string surname, DateTime birthday, string faculty, string post, int experience)
            : base(surname, birthday, faculty)
        {
            this._post = post;
            this._experience = experience;
        }

        new public void Print()
        {
            Console.Write("Teacher;  ");
            base.Print();
            Console.WriteLine("; Post: {0}; Experience: {1}", _post, _experience);
        }
    }
}
