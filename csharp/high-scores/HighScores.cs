using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    protected List<int> _scores;

    public HighScores(List<int> list)
    {
        _scores = list;
    }

    public List<int> Scores()
    {
        return _scores;
    }

    public int Latest()
    {
        return _scores.FindLast(item => true);
    }

    public int PersonalBest()
    {
        return _scores.Max();
    }

    public List<int> PersonalTopThree()
    {
        return _scores.OrderBy(i => -i).Take(3).ToList();
        // return _scores.OrderBy()
    }
}