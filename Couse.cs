using System;
using Pro;
public namespace Course {
    public class Course
    {
        private string _Cname;
        private string _Instructor;
        private string _Duration;

        public Course(string Cname, string Instructor, string Duration)
        {
            _Cname = Cname;
            _Instructor = Instructor;
            _Duration = Duration;
        }
        public string Cname
        {
            get
            {
                return _Cname;
            }
        }
        public string Instructor
        {
            get
            {
                return _Instructor;
            }
        }
        public string Duration
        {
            get
            {
                return _Duration;
            }

        }
        public void Details()
        {
            Consoler.WriteLine($"CourseName {}, Instructor {},"Duration { });
            
        }
    }
}