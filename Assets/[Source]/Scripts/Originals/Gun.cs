using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera cam;

    public TextMeshProUGUI txt;

    private int ammo = 3;
    private GM gm;

    //void Start()
    //{
    //    gm = FindObjectOfType<GM>();
    //    txt.text = "Ammo: " + ammo.ToString();
    //}

    public void Shoot()
    {
        gm.actions--;
        if (gm.actions == 0)
        {
            gm.podeAvancar = true;
        }

        if (ammo > 0)
        {
            ammo--;
            txt.text = "Ammo: " + ammo.ToString();
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Target tgt = hit.transform.GetComponent<Target>();
                if (tgt != null)
                {
                    tgt.TakeDamage(damage);
                }
            }
        }
    }

    public void Reload()
    {
        gm.actions--;
        if(gm.actions==0)
        {
            gm.podeAvancar = true;
        }

        ammo = 3;
        txt.text = "Ammo: " + ammo.ToString();
    }
}
