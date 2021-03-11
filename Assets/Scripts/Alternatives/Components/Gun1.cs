using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : Element
{
    [Header("References")]
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private LineRenderer lr;
    [SerializeField]
    private Transform shootPoint;

    public void Shoot()
    {
        app.model.playerData.Actions--;

        if (app.model.playerData.Ammo > 0)
        {
            app.model.playerData.Ammo--;

            ShotEffects();

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, app.model.playerData.playerRange))
            {
                lr.SetPosition(0, shootPoint.position);
                lr.SetPosition(1, hit.point);

                Enemy1 tgt = hit.transform.GetComponent<Enemy1>();
                if (tgt != null)
                {
                    app.controller.enemiesController.RemoveEnemy(tgt);
                }
            }
            
            LeanTween.moveLocalZ(gameObject, .07f, .7f).setEasePunch();
        }    
        else
        {
            app.model.playerData.failShot.Play();
        }
    }

    public void Reload()
    {
        app.model.playerData.Actions--;
        app.model.playerData.reload.Play();
        app.model.playerData.Ammo = app.model.playerData.maxAmmo;
    }

    private void ShotEffects()
    {
        GetComponent<AudioSource>().Play();
        ps.Play();
    }
}
