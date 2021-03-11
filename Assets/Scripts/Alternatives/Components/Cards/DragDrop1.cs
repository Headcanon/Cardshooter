using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop1 : Element
{
    public CollisionManager col;
    public CardEffects ef;
    public Vector2 bigScale;

    private bool isDraggin;
    private Vector2 startPosition;

    void Update()
    {
        if (isDraggin)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDraggin = true;
    }

    public void EndDrag()
    {
        isDraggin = false;

        if (col.isOverDropZone)
        {
            ef.ActivateEffect();
        }
        else
        {
            transform.position = startPosition;
        }    
    }

    public void HoverEnter()
    {
        LeanTween.scale(gameObject, bigScale, .085f);
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + 20, .085f);
    }

    public void HoverExit()
    {
        LeanTween.scale(gameObject, Vector2.one, .085f);
        LeanTween.moveLocalY(gameObject, transform.localPosition.y - 20, .085f);
    }
}

    
