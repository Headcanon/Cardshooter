using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : Element
{
    public IEnumerator EnemiesTurn()
    {
        if (app.model.estado.Comparar(Estado.ENEMIES_TURN))
        {
            int enemiesToGo = app.model.enemiesData.Enemies.Count;
            app.model.interfaceReferences.enemiesTxt.text = enemiesToGo.ToString();

            foreach (Enemy1 e in app.model.enemiesData.Enemies)
            {
                yield return new WaitForSeconds(app.model.enemiesData.enemiesWaitTime);

                if (app.model.estado.Comparar(Estado.ENEMIES_TURN))
                {                    
                    e.Attack();
                    enemiesToGo--;
                    app.model.interfaceReferences.enemiesTxt.text = enemiesToGo.ToString();
                }

            }
            yield return new WaitForSeconds(app.model.enemiesData.enemiesWaitTime);

            app.model.playerData.Actions = app.model.playerData.maxActions;
            app.controller.stateSwitcher.SwitchToStart();
        }
    }

    public void RemoveEnemy(Enemy1 e)
    {
        app.model.enemiesData.Enemies.Remove(e);
        Destroy(e.gameObject);

        if(app.model.enemiesData.Enemies.Count == 0)
        {
            app.controller.stateSwitcher.SwitchToWin();
        }
    }
}
