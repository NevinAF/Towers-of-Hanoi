using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Counter
{
    private void Start()
    {
        min = 0;
        max = 5;
    }
    protected override string GetText()
    {
        switch(num)
        {
            case 0: return "Pause";
            case 1: return "Slow";
            case 2: return "Normal";
            case 3: return "Fast";
            case 4: return "Fast+";
            case 5: return "Fast++";
            default: return "Out of order";
        }
    }

    public float GetSpeed()
    {
        switch (num)
        {
            case 0: return 0f;
            case 1: return 2f;
            case 2: return 5f;
            case 3: return 20f;
            case 4: return 100f;
            case 5: return 400f;
            default: return 0f;
        }
    }
}
