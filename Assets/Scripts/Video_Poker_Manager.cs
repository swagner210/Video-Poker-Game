using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Video_Poker_Manager : MonoBehaviour
{
    public Card_Manager thisdeck;
    public Player_Hand PHand;
    int[] temphand = new int[5];
    int[] TempHandSuite = new int[5];
    //int[] temphand = new int[] { 9,10,11,12,13};
    //int[] TempHandSuite = new int[] { 2, 2, 2, 2, 2 };


    public Betting_Manager BM;

    public AudioSource MoneySound;
    public TextMeshProUGUI Winner_Text;
    public TextMeshProUGUI WinningMoneyText;

    bool jacksorbetter = false;
    bool threeofkind = false;
    bool fourofkind = false;
    bool FullHouse = false;
    bool RoyalFlush = false;
    bool StraightFlush = false;
    bool flush = false;
    bool straight = false;
    bool two_pair = false;


    public void Awake()
    {
        thisdeck = GameObject.Find("Card Manager").GetComponent<Card_Manager>();
        PHand = GameObject.Find("Card Manager").GetComponent<Player_Hand>();
        MoneySound = GetComponent<AudioSource>();
        Winner_Text = GameObject.Find("Winning Text").GetComponent<TextMeshProUGUI>();
        Winner_Text.enabled = false;
        BM = GetComponent<Betting_Manager>();
        WinningMoneyText = GameObject.Find("Money Winning Text").GetComponent<TextMeshProUGUI>();
        WinningMoneyText.enabled = false;
    }

    public void CheckWinnings()
    {
        ArraySort();
        two_pair = TwoPairCheck();
        MultipleCheck();
        flush = FlushCheck();
        straight = StraightCheck();
        StraightFlush = StraightFlushCheck();
        RoyalFlush = RoyalFlushCheck();

        Outcome();

        jacksorbetter = false;
        threeofkind = false;
        fourofkind = false;
        FullHouse = false;
        RoyalFlush = false;
        StraightFlush = false;
        flush = false;
        straight = false;
        two_pair = false;
    }

    public void ChangeColor()
    {

    }

    public void ArraySort()
    {

        for (int i = 0; i < 5; i++)
        {
            if (PHand.hand[i].getValue() == 0)
            {
                temphand[i] = 13;
                TempHandSuite[i] = PHand.hand[i].GetSuite();
            }
            else
            {
                temphand[i] = PHand.hand[i].getValue();
                TempHandSuite[i] = PHand.hand[i].GetSuite();
            }
        }
        Array.Sort(temphand);

    }

    public bool TwoPairCheck()
    {

        int paircount = 0;
        int tempcount = 1;
        for (int i = 0; i < temphand.Length - 1; i++)
        {
            if (temphand[i] == temphand[i + 1])
            {
                tempcount++;
                if (tempcount == 2)
                {
                    paircount++;
                }
            }

            tempcount = 1;
        }
        if (paircount == 2)
        {
            return true;
        }
        return false;
    }

    public void MultipleCheck()
    {
        int highestcount = 1;
        int highestnum = 0;
        int lowestcount = 1;
        int tempcount = 1;


       for(int i = 0; i < temphand.Length -1 ; i++)
        {
            if (temphand[i] == temphand[i + 1])
            {
                tempcount++;
            }
            else
            {
                tempcount = 1;
            }

            if (tempcount > highestcount)
            {
                highestcount = tempcount;
                highestnum = temphand[i];
            }
            else if(tempcount > lowestcount)
            {
                lowestcount = tempcount;
            }
            
        }

        if (highestcount == 4)
        {
            fourofkind = true;

        }
        if (highestcount >= 3)
        {
            threeofkind = true;

            if (lowestcount == 2)
            {
                FullHouse = true;
            }
        }

        if(highestcount >= 2 && (highestnum >= 10 || highestnum == 0))
        {
                jacksorbetter = true;
        }
        
    }

    public bool StraightCheck()
    {

        for (int i = 0; i < temphand.Length - 1; i++)
        {
            if(temphand[i] + 1 != temphand[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public bool FlushCheck()
    {

        int MainSuite = TempHandSuite[0];

        for (int i = 1; i < TempHandSuite.Length - 1; i++)
        {
            if(TempHandSuite[i] != MainSuite)
            {
                
                return false;
            }
        }
        return true;
    }

    public bool StraightFlushCheck()
    {
        return flush && straight;
    }

    public bool RoyalFlushCheck()
    {

        if (flush && straight && temphand[0] == 9)
        {
            return true;
        }

        return false;
    }


    private IEnumerator Show_Winning_Message(string WinningMessage, string MoneyWon)
    {
        Winner_Text.SetText(WinningMessage);
        WinningMoneyText.SetText("$" + MoneyWon);
        Winner_Text.enabled = true;
        WinningMoneyText.enabled = true;

        yield return new WaitForSeconds(2.0f);
        Winner_Text.enabled = false;
        WinningMoneyText.enabled = false;
    }

    public void Outcome()
    {
        float MoneyWon = 0;

        if (RoyalFlush)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(800f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Royal Flush!", MoneyWon.ToString("F2")));

}
        else if (StraightFlush)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(50f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Straight Flush!", MoneyWon.ToString("F2")));

        }
        else if (fourofkind)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(25f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Four Of A Kind!", MoneyWon.ToString("F2")));

        }
        else if (FullHouse)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(9f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Fullhouse!", MoneyWon.ToString("F2")));

        }
        else if (flush)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(6f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Flush!", MoneyWon.ToString("F2")));

        }
        else if (straight)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(4f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Straight!", MoneyWon.ToString("F2")));
        }
        else if (threeofkind)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(3f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Three Of A Kind!", MoneyWon.ToString("F2")));
        }
        else if (two_pair)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(2f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Two Pair!", MoneyWon.ToString("F2")));

        }
        else if (jacksorbetter)
        {
            MoneySound.Play();
            MoneyWon = BM.WinningAmount(1f);
            BM.UpdateMoney(MoneyWon);
            StartCoroutine(Show_Winning_Message("Pair of Jacks Or Better!", MoneyWon.ToString("F2")));

        }
        else
        {
            MoneyWon = 0f;
            StartCoroutine(Show_Winning_Message("Lost :(", MoneyWon.ToString("F2")));
            BM.PlayerMoney -= BM.MainBet;
            BM.PlayerMoneyText.text = "$" + BM.PlayerMoney.ToString("F2");
        }



    }

    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
