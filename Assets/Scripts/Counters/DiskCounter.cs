using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskCounter : Counter
{
    private void Start()
    {
        min = 1;
        max = 27;
    }

    protected override string GetText()
    {
        return GetDisks().ToString();
    }

    public int GetDisks()
    {
        if (num <= 10)
            return num;
        if (num <= 15)
            return (10 + ((num - 10) * 2));
        if (num <= 19)
            return (10 + 10 + ((num - 15) * 5));
        if (num <= 25)
            return (10 + 10 + 20 + ((num - 19) * 10));
        switch (num)
        {
            case 25: return 200;
            case 26: return 400;
            case 27: return 1000;
            default: return 0;
        }
    }
}
