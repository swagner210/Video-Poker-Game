using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //Heart = 0
    //Spade = 1
    //club = 2
    //Diamond = 3;
    int suite;
    int value;

    public int GetSuite()
    {
        return suite;
    }

    public int getValue()
    {
        return value;
    }

    public void SetSuite(int SuiteVal)
    {
        suite = SuiteVal;
    }

    public void SetValue(int CardValue)
    {
        value = CardValue;
    }
}
