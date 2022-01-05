using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : Element
{
    [Header("Game")]
    public Estado estado;

    [Header ("Cards data")]
    public List<GameObject> possibleCards;

    [Header("Models")]
    public PlayerData playerData;
    public InterfaceReferences interfaceReferences;
    public EnemiesData enemiesData;
   
}
