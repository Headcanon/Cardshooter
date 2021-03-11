using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesData : MonoBehaviour
{
    [Header("Enemies data")]
    public float enemyDamage = 1f;
    public float enemyRange = 100f;
    public float enemiesWaitTime = 2f;

    public List<Enemy1> Enemies;

    private void Start()
    {
        Enemies = new List<Enemy1>();
        Enemies.AddRange(FindObjectsOfType<Enemy1>());
    }
}
