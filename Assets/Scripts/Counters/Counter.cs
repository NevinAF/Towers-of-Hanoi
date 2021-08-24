using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Counter : MonoBehaviour
{
    public int num;
    public Text text;
    protected int min, max;

    private void Start()
    {
        text.text = GetText();
    }

    public void Increment()
    {
        if(num < max)
            num++;
        text.text = GetText();
    }

    public void Decrement()
    {
        if(num > min)
            num--;
        text.text = GetText();
    }

    protected abstract string GetText();
    
}
