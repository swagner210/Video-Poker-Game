using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Betting_Manager : MonoBehaviour
{
    public float StartingMoney = 100.00f;
    public float StartingBet = .25f;
    public float MainBet;
    public float PlayerMoney;

    public TextMeshProUGUI BettingText;
    public TextMeshProUGUI PlayerMoneyText;



    public void Awake()
    {
        BettingText = GameObject.Find("Your Bet").GetComponent<TextMeshProUGUI>();
        PlayerMoneyText = GameObject.Find("Your Money Text").GetComponent<TextMeshProUGUI>();

    }

    public void Start()
    {
        MainBet = StartingBet;
        PlayerMoney = StartingMoney;

        BettingText.text = "$" + MainBet.ToString("F2");
        PlayerMoneyText.text = "$" + PlayerMoney.ToString("F2");
    }

    public void IncreaseBet()
    {
        if (MainBet <= 4.75f)
        {
            MainBet += .25f;
            BettingText.text = "$" + MainBet.ToString("F2");
        }
    }

    public void DecreaseBet()
    {
        if (MainBet > .25f)
        {
            MainBet -= .25f;
            BettingText.text = "$" + MainBet.ToString("F2");
        }
    }

    //Get the amount the player won per hand and return it float
    public float WinningAmount(float multipliyer)
    {
        float Winnings = 0f;
        Winnings = MainBet * multipliyer;
        return Winnings;
    }

    public void UpdateMoney(float NewEarnings)
    {
        PlayerMoneyText.text = "$" + (PlayerMoney + NewEarnings).ToString("F2");
    }

    //Reset player money to $100 so they can keep playing.
    public void ResetMoney()
    {
        PlayerMoney = 100f;
        PlayerMoneyText.text = "$" + PlayerMoney.ToString("F2");
    }


}
