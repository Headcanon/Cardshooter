using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Element
{
    [SerializeField]
    private LineRenderer lr;
    [SerializeField]
    private Transform shootPoint;

    public void Attack()
    {
        transform.LookAt(app.model.playerData.playerTransform);

        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, transform.forward, out hit, app.model.enemiesData.enemyRange))
        {
            GetComponent<AudioSource>().Play();
            lr.SetPosition(0, shootPoint.position);
            lr.SetPosition(1, hit.point);

            if (hit.transform.CompareTag("Player"))
            {
                if (app.model.playerData.Shielded)
                {
                    app.controller.playerController.ShieldDown();
                }
                else
                {
                    app.model.playerData.PlayerHealth--;
                }
            }
        }
    }
}
