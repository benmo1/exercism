using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    protected struct Student {
        public string name;
        public int grade;       
    }

    protected List<Student> _students = new List<Student> {};

    public void Add(string student, int grade)
    {
        Student s = new Student();
        s.name = student;
        s.grade = grade;
        _students.Add(s);
    }

    public IEnumerable<string> Roster()
    {
        return from s in _students orderby s.grade, s.name select s.name;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return from s in _students where s.grade == grade orderby s.name select s.name;
    }
}