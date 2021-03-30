using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCard : MonoBehaviour
{
    [SerializeField] private GameObject Card_Back;
    [SerializeField] private Controller controller;
    private int m_id;

    //Card Reveal
    private void OnMouseDown()
    {
        //local active state
        if (Card_Back.activeSelf && controller.canReveal)
        {
            Card_Back.SetActive(false);
            controller.CardRev(this);
        }
    }
    public void Reveal()
    {
        Card_Back.SetActive(true);
    }


    public int GetId() { return m_id;}

    // Img for all Items
    public void ChangeImage(int id, Sprite img)
    {
        m_id = id;
        GetComponent<SpriteRenderer>().sprite = img; 
    }



}
