using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public List<GameObject> possibleCards;
    public GameObject deck;

    private GM gm;
    
    //void Start()
    //{
    //    gm = FindObjectOfType<GM>();
    //}

    public void DrawCard()
    {
        gm.actions--;
        if (gm.actions == 0)
        {
            gm.podeAvancar = true;
        }

        for (int i = deck.transform.childCount; i < 5; i++)
        {
            GameObject card = Instantiate(possibleCards[Random.Range(0, possibleCards.Count)], Vector3.zero, Quaternion.identity);
            card.transform.SetParent(deck.transform);
        }
    }
}
