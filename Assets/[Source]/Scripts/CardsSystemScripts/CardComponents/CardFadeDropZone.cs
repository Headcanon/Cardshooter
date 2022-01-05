using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFadeDropZone : CardComponent
{
    public float FadeInValue = 1f;
    public float FadeOutValue = .4f;

    private Image img;

    private void Awake()
    {
        cardBase.OnOverDropZone += FadeOut;
        cardBase.OnOutOfDropZone += FadeIn;
    }

    private void FadeIn()
    {
        if (dropZone != null)
        {
            img = dropZone.GetComponent<Image>();
            img.CrossFadeAlpha(FadeInValue, .085f, false);
        }
    }

    private void FadeOut()
    {
        if (dropZone != null)
        {
            img = dropZone.GetComponent<Image>();
            img.CrossFadeAlpha(FadeOutValue, .085f, false);
        }
    }
}

    
