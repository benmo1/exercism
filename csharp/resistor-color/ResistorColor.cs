using System;
using System.Collections.Generic;

public static class ResistorColor
{
    private readonly static Dictionary<string, int> _map = new Dictionary<string, int>() {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    };

    public static int ColorCode(string color)
    {
        return _map[color];
    }

    public static string[] Colors()
    {
        string[] res = new string[_map.Count];
        _map.Keys.CopyTo(res, 0);

        return res;
    }
}