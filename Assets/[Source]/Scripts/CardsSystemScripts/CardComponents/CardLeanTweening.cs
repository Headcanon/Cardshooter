using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLeanTweening : CardComponent
{
    public Vector2 bigScale;

    private Vector3 initialPosition;
        
    private void Awake()
    {
        cardBase.OnEffect += EffectTween;
        cardBase.OnStartHover += HoverEnterTween;
        cardBase.OnEndHover += HoverExitTween;

        initialPosition = cardBase.transform.position;
    }

    private void EffectTween()
    {
        LeanTween.scale(cardBase.gameObject, Vector2.zero, .085f).setOnComplete(DestroyCard);
    }

    private void HoverEnterTween()
    {
        LeanTween.scale(cardBase.gameObject, bigScale, .085f);
        LeanTween.moveLocalY(cardBase.gameObject, initialPosition.y + 40, .085f);
    }

    private void HoverExitTween()
    {
        LeanTween.scale(cardBase.gameObject, Vector2.one, .085f);
        LeanTween.moveLocalY(cardBase.gameObject, initialPosition.y + 20, .085f);
    }
}
