using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Placed on Card Prefab
public class Card : MonoBehaviour
{
    int cardID;
    public SpriteRenderer cardFront;
    public Animator anim;

    public void SetCard(int _id, Sprite _sprite)
    {
        cardID = _id;
        cardFront.sprite = _sprite;
    }

    //prze³¹cza paramtetr (w Animator) flippedOpnen, a jesli on jest true to z idle przechodzi do animacji FlipedOpen
    public void FlipOpen(bool flipped)
    {
     
            anim.SetBool("flippedOpen", flipped);
              
    }

    public int GetCardId()
    {
        return cardID;
    }

}
