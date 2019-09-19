using System;
using System.Collections.Generic;
using System.Text;
public class Robot
{
    protected static Random _random = new Random();

    protected static StringBuilder _sb = new StringBuilder("", 5);

    protected static List<string> _names = new List<string> {};
    protected string _name = "";

    public string Name
    {
        get
        {
            if (_name == "") {
                do {
                    _name = newName();
                } while (_names.Contains(_name));
                _names.Add(_name);
            }

            return _name;
        }
    }

    protected string newName() {
        _sb.Clear();
        _sb.Append(randomAlpha());
        _sb.Append(randomAlpha());
        _sb.Append(randomNumber());
        _sb.Append(randomNumber());
        _sb.Append(randomNumber());

        return _sb.ToString();
    }

    protected char randomAlpha() {
        return (char) ('A' + _random.Next(0, 26));
    }

    protected int randomNumber() {
        return _random.Next(0, 10);
    }

    public void Reset()
    {
        _name = "";
    }
}