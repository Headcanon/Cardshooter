using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Element
{
    public void ShieldUp()
    {
        app.model.playerData.Actions--;
        app.model.playerData.Shielded = true;
    }

    public void ShieldDown()
    {
        app.model.playerData.Shielded = false;
    }

    public void UpActions()
    {
        app.model.playerData.Actions++;
    }
}
