using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : Element
{
    private DamageIndicatorController ic;
    private void Start()
    {
        ic = GetComponent<DamageIndicatorController>();

        OnHealthUpdate();
        OnActionsUpdate();
        OnAmmoUpdate();
    }

    #region Text Updaters
    public void OnActionsUpdate()
    {
        app.model.interfaceReferences.actionsTxt.text = "Actions: " + app.model.playerData.Actions;
        GetComponent<TutorialController>().NextTutorial();
    }
    public void OnAmmoUpdate()
    {
        app.model.interfaceReferences.ammoTxt.text = "Ammo: " + app.model.playerData.Ammo;
    }
    public void OnHealthUpdate()
    {
        app.model.interfaceReferences.healthTxt.text = "Health: " + app.model.playerData.PlayerHealth;

        if (app.model.estado.Comparar(Estado.ENEMIES_TURN))
        {
            app.model.playerData.hit.Play();
            ic.IndicateDamage(.4f); 
        }
    }
    public void OnShieldUpdate()
    {
        ic.IndicateShield(.4f);
    }
    #endregion

    #region Viewing Templates
    public void SetMiraTemplate()
    {
        app.model.interfaceReferences.botoes.SetActive(false);
        app.model.interfaceReferences.mira.SetActive(true);
        app.model.interfaceReferences.clickInstructionsTxt.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetStartTemplate()
    {
        app.model.interfaceReferences.botoes.SetActive(true);
        app.model.interfaceReferences.mira.SetActive(false);
        app.model.interfaceReferences.enemiesObj.SetActive(false);
        app.model.interfaceReferences.clickInstructionsTxt.SetActive(false);
        app.model.interfaceReferences.walkInstructionsTxt.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetWalkTemplate()
    {
        app.model.interfaceReferences.botoes.SetActive(false);
        app.model.interfaceReferences.mira.SetActive(false);
        app.model.interfaceReferences.walkInstructionsTxt.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetEnemiesTurnTemplate()
    {
        app.model.interfaceReferences.enemiesObj.SetActive(true);
        app.model.interfaceReferences.mira.SetActive(false);
        app.model.interfaceReferences.botoes.SetActive(false);
        app.model.interfaceReferences.clickInstructionsTxt.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetLoseStateTemplate()
    {
        app.model.interfaceReferences.botoes.SetActive(false);
        app.model.interfaceReferences.enemiesObj.SetActive(false);
        app.model.interfaceReferences.playerInfo.SetActive(false);
        app.model.interfaceReferences.loseTxt.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetWinStateTemplate()
    {
        app.model.interfaceReferences.botoes.SetActive(false);
        app.model.interfaceReferences.enemiesObj.SetActive(false);
        app.model.interfaceReferences.playerInfo.SetActive(false);
        app.model.interfaceReferences.winTxt.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion
}
