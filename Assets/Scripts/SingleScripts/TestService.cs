using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestService : ScriptableObject
{
    private int test = 0;

    public void SetValue(int value)
    {
        test = value;
    }

    public void PrintValue()
    {
        Debug.Log(test);
    }
    
}
