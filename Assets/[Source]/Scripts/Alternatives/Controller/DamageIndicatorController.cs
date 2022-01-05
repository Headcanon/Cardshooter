using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicatorController : Element
{
    private void Start()
    {
        app.model.interfaceReferences.DamageIndicator.CrossFadeAlpha(0, 0, true);
        app.model.interfaceReferences.ShieldIndicator.CrossFadeAlpha(0, 0, true);
    }

    public void IndicateDamage(float time)
    {
        app.model.interfaceReferences.DamageIndicator.CrossFadeAlpha(1, time, true);
        StartCoroutine(HideIndicator(time));
    }

    private IEnumerator HideIndicator(float time)
    {
        yield return new WaitForSeconds(time);

        app.model.interfaceReferences.DamageIndicator.CrossFadeAlpha(0, time, true);
    }

    public void IndicateShield(float time)
    {
        if(app.model.playerData.Shielded)
        {
            app.model.playerData.shieldUp.Play();
            app.model.interfaceReferences.ShieldIndicator.CrossFadeAlpha(1, time, true);
        }
        else
        {
            app.model.playerData.shieldDown.Play();
            app.model.interfaceReferences.ShieldIndicator.CrossFadeAlpha(0, time/2, true);
        }
    }
}
