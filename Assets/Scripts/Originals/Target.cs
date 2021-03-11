using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public bool shield;

    public float hp = 50f;

    public TextMeshProUGUI txt;

    private GM gm;

    //private void Start()
    //{
    //    gm = FindObjectOfType<GM>();

    //    if (txt != null)
    //    {
    //        txt.text = "Health: " + hp.ToString();
    //    }
    //}

    public void TakeDamage (float amount)
    {
        if (!shield)
        {
            hp -= amount;

            if (txt != null)
            {
                txt.text = "Health: " + hp.ToString();
            }

            if (hp <= 0)
            {
                //Die();
            }
        }
    }

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}

    public void SetShield(bool set)
    {
        gm.actions--;
        if (gm.actions == 0)
        {
            gm.podeAvancar = true;
        }
        shield = set;
    }

}
