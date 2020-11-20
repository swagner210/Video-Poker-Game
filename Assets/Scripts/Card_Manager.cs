using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card_Manager : MonoBehaviour
{
    public List<Card> StartingDeck = new List<Card>();
    public Player_Hand PHand;
    public Video_Poker_Manager VPM;
    SpriteChanger SC;

    Button DealButton;
    Button DrawButton;
    Button Hold1;
    Button Hold2;
    Button Hold3;
    Button Hold4;
    Button Hold5;

    Image card1;
    Image card2;
    Image card3;
    Image card4;
    Image card5;

    public TextMeshProUGUI Held1;
    public TextMeshProUGUI Held2;
    public TextMeshProUGUI Held3;
    public TextMeshProUGUI Held4;
    public TextMeshProUGUI Held5;

    public int count = 0;

    private void Awake()
    {
        DealButton = GameObject.Find("Deal_Button").GetComponent<Button>();
        DrawButton = GameObject.Find("Draw_Button").GetComponent<Button>();

        Held1 = GameObject.Find("Held1Text").GetComponent<TextMeshProUGUI>();
        Held2 = GameObject.Find("Held2Text").GetComponent<TextMeshProUGUI>();
        Held3 = GameObject.Find("Held3Text").GetComponent<TextMeshProUGUI>();
        Held4 = GameObject.Find("Held4Text").GetComponent<TextMeshProUGUI>();
        Held5 = GameObject.Find("Held5Text").GetComponent<TextMeshProUGUI>();

        Hold1 = GameObject.Find("Hold_Button_Spot_1").GetComponent<Button>();
        Hold2 = GameObject.Find("Hold_Button_Spot_2").GetComponent<Button>();
        Hold3 = GameObject.Find("Hold_Button_Spot_3").GetComponent<Button>();
        Hold4 = GameObject.Find("Hold_Button_Spot_4").GetComponent<Button>();
        Hold5 = GameObject.Find("Hold_Button_Spot_5").GetComponent<Button>();

        PHand = GameObject.Find("Card Manager").GetComponent<Player_Hand>();
        VPM = GameObject.Find("Poker_Manager").GetComponent<Video_Poker_Manager>();
        SC = GameObject.Find("Sprite_Manager").GetComponent<SpriteChanger>();
        card1 = GameObject.Find("Card1").GetComponent<Image>();
        card2 = GameObject.Find("Card2").GetComponent<Image>();
        card3 = GameObject.Find("Card3").GetComponent<Image>();
        card4 = GameObject.Find("Card4").GetComponent<Image>();
        card5 = GameObject.Find("Card5").GetComponent<Image>();
    }

    void Start()
    {
        DrawButton.gameObject.SetActive(false);
        Hold1.gameObject.SetActive(false);
        Hold2.gameObject.SetActive(false);
        Hold3.gameObject.SetActive(false);
        Hold4.gameObject.SetActive(false);
        Hold5.gameObject.SetActive(false);
        Held1.enabled = false;
        Held2.enabled = false;
        Held3.enabled = false;
        Held4.enabled = false; 
        Held5.enabled = false;

        int CardCount = 0;

        //Creats the starting deck of type cards
        for(int i =0;i<4; i++)
        {
            for(int j =0;j<13; j++)
            { 
                Card card = new Card();
                card.SetSuite(i);
                card.SetValue(j);
                StartingDeck.Add(card);
                CardCount++;
            }
        }
        FisherYates_Shuffle();
    }

    public void DealHand()
    {
    
        Hold1.gameObject.SetActive(true);
        Hold2.gameObject.SetActive(true);
        Hold3.gameObject.SetActive(true);
        Hold4.gameObject.SetActive(true);
        Hold5.gameObject.SetActive(true);
        //Sets each card in player hand to new card in deck
        PHand.hand[0] = StartingDeck[count];
        SC.ChangeSprite(card1, 0);
        count++;
        CountCheck();

        PHand.hand[1] = StartingDeck[count];
        SC.ChangeSprite(card2,1);
        count++;
        CountCheck();

        PHand.hand[2] = StartingDeck[count];
        SC.ChangeSprite(card3,2);
        count++;
        CountCheck();

        PHand.hand[3] = StartingDeck[count];
        SC.ChangeSprite(card4,3);
        count++;
        CountCheck();

        PHand.hand[4] = StartingDeck[count];
        SC.ChangeSprite(card5,4);
        count++;
        CountCheck();

        //Deactivate this button and set the draw button
        DealButton.gameObject.SetActive(false);
        DrawButton.gameObject.SetActive(true);
    }

    public void DrawHand()
    {
        Held1.enabled = false;
        Held2.enabled = false;
        Held3.enabled = false;
        Held4.enabled = false;
        Held5.enabled = false;
        Hold1.gameObject.SetActive(false);
        Hold2.gameObject.SetActive(false);
        Hold3.gameObject.SetActive(false);
        Hold4.gameObject.SetActive(false);
        Hold5.gameObject.SetActive(false);
        //Checks to see if any cards were held and only replaces the ones which were not
        if (!PHand.spot1)
        {
            PHand.hand[0] = StartingDeck[count];
            SC.ChangeSprite(card1,0);
            count++;
            CountCheck();
        }

        if (!PHand.spot2)
        {
            PHand.hand[1] = StartingDeck[count];
            SC.ChangeSprite(card2,1);
            count++;
            CountCheck();
        }

        if (!PHand.spot3)
        {
            PHand.hand[2] = StartingDeck[count];
            SC.ChangeSprite(card3,2);
            count++;
            CountCheck();
        }

        if (!PHand.spot4)
        {
            PHand.hand[3] = StartingDeck[count];
            SC.ChangeSprite(card4,3);
            count++;
            CountCheck();
        }

        if (!PHand.spot5)
        {
            PHand.hand[4] = StartingDeck[count];
            SC.ChangeSprite(card5,4);
            count++;
            CountCheck();
        }

        PHand.SetFalse();
        VPM.CheckWinnings();
        DealButton.gameObject.SetActive(true);
        DrawButton.gameObject.SetActive(false);
    }

    //Shuffle deck is all 52 cards are used
    public void CountCheck()
    {
        if(count == 52)
        {
            FisherYates_Shuffle();
            count = 0;
        }
    }

    //Shuffling algorithm of the cards
    public void FisherYates_Shuffle()
    {
        int j = 0;
        Card tempvalue;
        for (int i = 0; i < 52; i++)
        {
            j = Random.Range(0, 51);
            tempvalue = StartingDeck[i];
            StartingDeck[i] = StartingDeck[j];
            StartingDeck[j] = tempvalue;
        }
    }

    //Set the flags for if the player holds the card at the specific position
    public void setholdflag1()
    {
        if (PHand.spot1 == true)
        {
            Held1.enabled = false;
            PHand.spot1 = false;
        }
        else
        {
            Held1.enabled = true;
            PHand.spot1 = true;
        }

    }
    public void setholdflag2()
    {
        if (PHand.spot2 == true)
        {
            Held2.enabled = false;
            PHand.spot2 = false;
        }
        else
        {
            Held2.enabled = true;
            PHand.spot2 = true;
        }

    }
    public void setholdflag3()
    {
        if (PHand.spot3 == true)
        {
            Held3.enabled = false;
            PHand.spot3 = false;
        }
        else
        {
            Held3.enabled = true;
            PHand.spot3 = true;
        }

    }
    public void setholdflag4()
    {
        if (PHand.spot4 == true)
        {
            Held4.enabled = false;
            PHand.spot4 = false;
        }
        else
        {
            Held4.enabled = true;
            PHand.spot4 = true;
        }

    }
    public void setholdflag5()
    {
        if (PHand.spot5 == true)
        {
            Held5.enabled = false;
            PHand.spot5 = false;
        }
        else
        {
            Held5.enabled = true;
            PHand.spot5 = true;
        }

    }

}
