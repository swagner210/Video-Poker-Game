using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    List<Card> StartingDeck;
    Player_Hand PlayerHand;
    //int count;
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
        //int value = 0;
        //int suite = 0;
        int value = PlayerHand.hand[num].getValue();
        //count = cardmanager.count;
        int suite = PlayerHand.hand[num].GetSuite();

        //Debug.Log("Val: " + value + " . Suite: " + suite);

        if (suite == 0)
        {
            if( value == 0)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h01");
            }
            if (value == 1)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h02");
            }
            if (value == 2)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h03");
            }
            if (value == 3)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h04");
            }
            if (value == 4)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h05");
            }
            if (value == 5)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h06");
            }
            if (value == 6)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h07");
            }
            if (value == 7)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h08");
            }
            if (value == 8)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h09");
            }
            if (value == 9)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h10");
            }
            if (value == 10)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h11");
            }
            if (value == 11)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h12");
            }
            if (value == 12)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_h13");
            }


        }
        else if(suite == 1)
        {

            if (value == 0)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s01");
            }
            if (value == 1)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s02");
            }
            if (value == 2)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s03");
            }
            if (value == 3)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s04");
            }
            if (value == 4)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s05");
            }
            if (value == 5)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s06");
            }
            if (value == 6)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s07");
            }
            if (value == 7)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s08");
            }
            if (value == 8)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s09");
            }
            if (value == 9)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s10");
            }
            if (value == 10)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s11");
            }
            if (value == 11)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s12");
            }
            if (value == 12)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_s13");
            }


        }
        else if(suite == 2)
        {

            if (value == 0)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c01");
            }
            if (value == 1)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c02");
            }
            if (value == 2)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c03");
            }
            if (value == 3)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c04");
            }
            if (value == 4)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c05");
            }
            if (value == 5)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c06");
            }
            if (value == 6)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c07");
            }
            if (value == 7)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c08");
            }
            if (value == 8)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c09");
            }
            if (value == 9)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c10");
            }
            if (value == 10)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c11");
            }
            if (value == 11)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c12");
            }
            if (value == 12)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_c13");
            }


        }
        else
        {

            if (value == 0)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d01");
            }
            if (value == 1)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d02");
            }
            if (value == 2)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d03");
            }
            if (value == 3)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d04");
            }
            if (value == 4)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d05");
            }
            if (value == 5)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d06");
            }
            if (value == 6)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d07");
            }
            if (value == 7)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d08");
            }
            if (value == 8)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d09");
            }
            if (value == 9)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d10");
            }
            if (value == 10)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d11");
            }
            if (value == 11)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d12");
            }
            if (value == 12)
            {
                thisimage.sprite = Resources.Load<Sprite>("img_card_d13");
            }

        }
    }


}
