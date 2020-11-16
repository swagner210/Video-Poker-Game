using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

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

    //public int CompareTo(Card card)
    //{       // A null value means that this object is greater.
    //    if (card == null)
    //    {
    //        return 1;
    //    }
    //    else
    //    {
    //        return this.value.CompareTo(card.value);
    //    }
    //}
}
