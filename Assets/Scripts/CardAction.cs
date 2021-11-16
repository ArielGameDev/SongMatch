using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{
    GameObject[] cards;

    // Start is called before the first frame update
    void Start()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnMouseDown()
    {
        if(cards[0].transform == gameObject.transform)
            FindObjectOfType<AudioManager>().Play("tnt_start");
        if (cards[1].transform == gameObject.transform)
            FindObjectOfType<AudioManager>().Play("tnt_end");
    }


}
