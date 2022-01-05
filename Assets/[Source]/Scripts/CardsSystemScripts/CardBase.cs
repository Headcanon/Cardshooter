using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CardEvents();
public class CardBase : MonoBehaviour
{
    public event CardEvents OnBeginDrag;
    public event CardEvents OnEndDrag;
    public event CardEvents OnStartHover;
    public event CardEvents OnEndHover;
    public event CardEvents OnEffect;
    public event CardEvents OnOverDropZone;
    public event CardEvents OnOutOfDropZone;


    #region DragEvents
    private bool isDraggin;
    private Vector2 startPosition;

    private void Update()
    {
        if (isDraggin)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void BeginDrag()
    {
        startPosition = transform.position;
        isDraggin = true;

        OnBeginDrag?.Invoke();
    }

    public void EndDrag()
    {
        isDraggin = false;

        if (isOverDropZone)
        {
            OnEffect?.Invoke();
        }
        else
        {
            transform.position = startPosition;
        }

        OnEndDrag?.Invoke();
    }
    #endregion

    #region HoverEvents
    public void HoverEnter() { OnStartHover?.Invoke(); }
    public void HoverExit() { OnEndHover?.Invoke(); }
    #endregion

    #region DropZoneEvents
    public bool isOverDropZone;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DropZone"))
        {
            isOverDropZone = true;
            OnOverDropZone?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DropZone"))
        {
            isOverDropZone = false;
            OnOutOfDropZone?.Invoke();
        }
    }
    #endregion
}


