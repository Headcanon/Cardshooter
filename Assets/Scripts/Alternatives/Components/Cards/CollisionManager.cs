using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : Element
{
    public bool isOverDropZone;

    private GameObject dropZone;
    private Image img;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DropZone"))
        {
            isOverDropZone = true;
            img = collision.gameObject.GetComponent<Image>();
            img.CrossFadeAlpha(.4f, .085f, false);
        }
        //LeanTween.value(214, 50, .085f).setOnUpdate(SetDropZoneAlpha);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DropZone"))
        {
            isOverDropZone = false;
            img = collision.gameObject.GetComponent<Image>();
            img.CrossFadeAlpha(1, .085f, false);
        }
        //LeanTween.alpha(app.model.interfaceReferences.dropZone, 100, .03f);
    }

    private void SetDropZoneAlpha(float value)
    {
        //img.CrossFadeAlpha
    }
}

    
