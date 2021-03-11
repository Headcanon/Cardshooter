using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TipoCarta { SHOOT, RELOAD, SHIELD, EXTRA_ACTIONS }

public class CardEffects : Element
{
    public TipoCarta tipo;

    public void ActivateEffect()
    {
        LeanTween.scale(transform.parent.gameObject, Vector2.zero, .085f).setOnComplete(Effect);
    }

    private void Effect()
    {
        switch (tipo)
        {
            case TipoCarta.SHOOT:
                {
                    FindObjectOfType<Gun1>().Shoot();
                    break;
                }
            case TipoCarta.RELOAD:
                {
                    FindObjectOfType<Gun1>().Reload();
                    break;
                }
            case TipoCarta.SHIELD:
                {
                    app.controller.playerController.ShieldUp();
                    break;
                }
            case TipoCarta.EXTRA_ACTIONS:
                {
                    app.controller.playerController.UpActions();
                    break;
                }
        }

        Destroy(transform.parent.gameObject);
    }
}
