using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonView : Element
{
    public void OnAimClick()
    {
        if (app.model.playerData.Actions > 0)
        {
            app.model.playerData.Actions--;
            app.controller.stateSwitcher.SwitchToMira();
        }
    }

    public void OnWalkClick()
    {
        if (app.model.playerData.Actions > 0)
        {
            app.model.playerData.Actions--;
            app.controller.stateSwitcher.SwitchToWalk();
        }
    }

    public void OnDrawClick()
    {
        if (app.model.playerData.Actions > 0)
        {
            app.model.playerData.Actions--;
            app.controller.cardController.DrawCards();
        }
    }
}
