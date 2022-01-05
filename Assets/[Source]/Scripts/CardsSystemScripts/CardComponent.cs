using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    protected CardBase cardBase { get { return transform.parent.GetComponent<CardBase>(); } }

    protected DropZone dropZone { get { return FindObjectOfType<DropZone>(); } }

    protected void DestroyCard()
    {
        Destroy(cardBase.gameObject);
    }
}
