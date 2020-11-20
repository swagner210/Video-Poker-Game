using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    List<Card> StartingDeck;
    Player_Hand PlayerHand;
    Card_Manager cardmanager;


    public void Start()
    {
        cardmanager = GameObject.Find("Card Manager").GetComponent<Card_Manager>();
        StartingDeck = cardmanager.StartingDeck;
        PlayerHand = cardmanager.PHand;
    }

    //Heart = 0
    //Spade = 1
    //club = 2
    //Diamond = 3;

    public void ChangeSprite(Image thisimage, int num)
    {
        int value = PlayerHand.hand[num].getValue();
        int suite = PlayerHand.hand[num].GetSuite();
        string tempvalue;

        switch (suite)
        {
            case 0:
                tempvalue = $"{value:00}";
                thisimage.sprite = Resources.Load<Sprite>("img_card_h" + tempvalue);
                break;
            case 1:
                tempvalue = $"{value:00}";
                thisimage.sprite = Resources.Load<Sprite>("img_card_s" + tempvalue);
                break;
            case 2:
                tempvalue = $"{value:00}";
                thisimage.sprite = Resources.Load<Sprite>("img_card_c" + tempvalue);
                break;
            case 3:
                tempvalue = $"{value:00}";
                thisimage.sprite = Resources.Load<Sprite>("img_card_d" + tempvalue);
                break;
        }
    }
}
