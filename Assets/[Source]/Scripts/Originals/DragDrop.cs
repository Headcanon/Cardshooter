using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum TipoCarta { SHOOT, RELOAD, SHIELD, EXTRA_ACTIONS}

public class DragDrop : Element
{
    public TipoCarta tipo;

    private bool isDraggin;
    private bool isOverDropZone;

    private GameObject dropZone;
    private Vector2 startPosition;

    // Update is called once per frame
    void Update()
    {
        if(isDraggin)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDraggin = true;
    }

    public void EndDrag()
    {
        isDraggin = false;

        if(isOverDropZone)
        {
            LeanTween.scale(gameObject, Vector2.zero, .1f).setOnComplete(Effect);
        }
        else
        {
            transform.position = startPosition;
        }
    }

    private void Effect()
    {
        switch (tipo)
        {
            case TipoCarta.SHOOT:
                {
                    FindObjectOfType<Gun1>().Shoot();
                    break;
                }
            case TipoCarta.RELOAD:
                {
                    FindObjectOfType<Gun1>().Reload();
                    break;
                }
            case TipoCarta.SHIELD:
                {
                    app.controller.playerController.ShieldUp();
                    break;
                }
            case TipoCarta.EXTRA_ACTIONS:
                {
                    app.controller.playerController.UpActions();
                    break;
                }
        }

        Destroy(gameObject);
    }
}
