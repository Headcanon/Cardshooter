using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Element
{
    [Header("Controls")]
    public float playerDamage = 10f;
    public float playerRange = 100f;
    public float mouseSensitivity = 100f;

    [Header("Gameplay")]
    private bool shielded;
    public bool Shielded
    {
        get { return shielded; }
        set { shielded = value;
            app.controller.interfaceController.OnShieldUpdate(); }
    }

    #region Health data
    public int maxHealth = 3;
    private int playerHealth = 3;
    public int PlayerHealth
    {
        get { return playerHealth; }
        set { if (value >= 0) playerHealth = value;
            app.controller.interfaceController.OnHealthUpdate(); }
    }
    #endregion

    #region Ammo data
    public int maxAmmo = 3;
    private int ammo = 3;
    public int Ammo
    {
        get { return ammo; }
        set { if (value >= 0) ammo = value;
            app.controller.interfaceController.OnAmmoUpdate(); }
    }
    #endregion

    #region Action data
    public int maxActions = 2;
    private int actions = 2;
    public int Actions
    {
        get { return actions; }
        set { if (value >= 0) actions = value;
            app.controller.interfaceController.OnActionsUpdate(); }
    }
    #endregion

    [Header("Physics")]
    public float moveSpeed = 12f;
    public float gravity = -9.81f;

    [Header("Audios")]
    public AudioSource hit;
    public AudioSource shieldUp;
    public AudioSource shieldDown;
    public AudioSource failShot;
    public AudioSource reload;

    // Transform
    public Transform playerTransform
    {
        get { return GameObject.FindGameObjectWithTag("Player").transform; }
    }
}
