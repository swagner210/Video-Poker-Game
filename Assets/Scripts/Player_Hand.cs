using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hand : MonoBehaviour
{
    public Card[] hand = new Card[5];

    public bool spot1 = false;
    public bool spot2 = false;
    public bool spot3 = false;
    public bool spot4 = false;
    public bool spot5 = false;

    public void SetFalse()
    {
        spot1 = false;
        spot2 = false;
        spot3 = false;
        spot4 = false;
        spot5 = false;
    }


}
