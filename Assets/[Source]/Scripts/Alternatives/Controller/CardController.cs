using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : Element
{
    public bool cardOnSpawn;
    private void Start()
    {
        if(cardOnSpawn)
        {
            DrawCards();
        }
    }

    public void DrawCards()
    {
        for (int i = app.model.interfaceReferences.deck.transform.childCount; i < 5; i++)
        {
            GameObject card = Instantiate(app.model.possibleCards[Random.Range(0, app.model.possibleCards.Count)], Vector3.zero, Quaternion.identity);
            card.transform.SetParent(app.model.interfaceReferences.deck.transform);
            card.transform.localScale = Vector2.one;
        }
    }
}
