using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    protected Dictionary<string, int> _students = new Dictionary<string, int> {};

    public void Add(string student, int grade)
    {
        _students.Add(student, grade);
    }

    public IEnumerable<string> Roster()
    {
        return from i in _students orderby i.Value, i.Key select i.Key;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return from i in _students where i.Value == grade orderby i.Key select i.Key;
    }
}