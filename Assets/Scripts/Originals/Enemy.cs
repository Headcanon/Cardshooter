using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 1f;
    public float range = 100f;

    private Transform player;
    private GM gm;

    // Start is called before the first frame update
    //void Start()
    //{
    //    player = FindObjectOfType<PlayerMovement>().transform;
    //    gm = FindObjectOfType<GM>();
    //}

    public void Attack()
    {
        transform.LookAt(player);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Target tgt = hit.transform.GetComponent<Target>();
            if (tgt != null)
            {
                tgt.TakeDamage(damage);
                tgt.SetShield(false);
            }
        }
    }

    //private void OnDestroy()
    //{
    //    gm.enemies.Remove(this);
    //}
}
