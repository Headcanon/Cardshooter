using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StateSwitcher : Element
{
    private SceneManager sm = new SceneManager();
    private Model model;

    private void Start()
    {
        model = app.model;
    }
    private void Update()
    {
        if (model.playerData.PlayerHealth <= 0)
        {
            SwitchToLose();
        }


        if (model.estado.Comparar(Estado.MIRAR) && Input.GetButtonDown("Fire1") || model.estado.Comparar(Estado.ANDAR) && Input.GetButtonDown("Fire1"))
        {
            SwitchToStart();
        }
        else if (model.estado.Comparar(Estado.START) && model.playerData.Actions <= 0)
        {
            SwitchToEnemiesTurn();
        }
        else if (model.estado.Comparar(Estado.LOSE_STATE) && Input.GetButtonDown("Fire1"))
        {
            sm.Reload();
        }
        else if (model.estado.Comparar(Estado.WIN_STATE) && Input.GetButtonDown("Fire1"))
        {
            sm.LoadNext();
        }

    }

    public void SwitchToStart()
    {
        model.estado = Estado.START;
        app.controller.interfaceController.SetStartTemplate();
    }

    private void SwitchToEnemiesTurn()
    {
        model.estado = Estado.ENEMIES_TURN;
        app.controller.interfaceController.SetEnemiesTurnTemplate();
        StartCoroutine(app.controller.enemiesController.EnemiesTurn());
    }

    private void SwitchToLose()
    {
        model.estado = Estado.LOSE_STATE;
        app.controller.interfaceController.SetLoseStateTemplate();
    }

    #region Public switchers
    public void SwitchToWin()
    {
        model.estado = Estado.WIN_STATE;
        app.controller.interfaceController.SetWinStateTemplate();
    }

    public void SwitchToMira()
    {
        model.estado = Estado.MIRAR;
        app.controller.interfaceController.SetMiraTemplate();
     
    }

    public void SwitchToWalk()
    {        
        model.estado = Estado.ANDAR;
        app.controller.interfaceController.SetWalkTemplate();
    }
    #endregion
}
