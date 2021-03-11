using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum Estado { START, MIRAR, ANDAR, ENEMIES_TURN, WIN_STATE, LOSE_STATE }

public class GM1 : MonoBehaviour
{
    private Estado currentState;

    public Estado CurrenState
    {
        get { return currentState; }
        set
        {
            currentState = value; 
        }
    }

    public TextMeshProUGUI txt;
    public GameObject botoes, mira, enemiesTxt, clickInstructions, winTxt, loseTxt;

    public int actions = 2;

    public List<Enemy> enemies;

    public bool podeAvancar;


    //void Start()
    //{
    //    estado = Estado.START;
    //    enemies = new List<Enemy>();
    //    enemies.AddRange(FindObjectsOfType<Enemy>());
    //}

    //void Update()
    //{
    //    txt.SetText("Actions: " + actions.ToString());

    //    if(enemies.Count <= 0)
    //    {
    //        SwitchToWin();
    //    }
    //    else if (actions <= 0 && podeAvancar)
    //    {
    //        StartCoroutine(SwitchToEnemiesTurn());
    //    }

    //    if(Input.GetKey(KeyCode.Escape))
    //    {
    //        Application.Quit();
    //    }

    //    switch (estado)
    //    {
    //        case Estado.START:
    //            {
    //                break;
    //            }

    //        case Estado.MIRAR:
    //            {
    //                if (Input.GetButton("Fire1"))
    //                {
    //                    if (actions > 0)
    //                    {
    //                        SwitchToStart();
    //                    }
    //                    else
    //                    {
    //                        podeAvancar = true;
    //                    }
    //                }
    //                break;
    //            }

    //        case Estado.ANDAR:
    //            {
    //                if (Input.GetButton("Fire1"))
    //                {
    //                    if (actions > 0)
    //                    {
    //                        SwitchToStart();
    //                    }
    //                    else
    //                    {
    //                        podeAvancar = true;
    //                    }
    //                }
    //                break;
    //            }

    //        case Estado.ENEMIES_TURN:
    //            {
    //                actions = 2;
    //                podeAvancar = false;
    //                //if (enemiesTurnTime > 0)
    //                //{
    //                //    enemiesTurnTime -= Time.deltaTime;
    //                //}
    //                //else
    //                //{
    //                //    actions = 2;
    //                //    SwitchToStart();
    //                //}
    //                break;
    //            }

    //    }
    //}

    #region Switch States
    public void SwitchToMira()
    {
        actions--;
        botoes.SetActive(false);
        mira.SetActive(true);
        clickInstructions.SetActive(true);
        currentState = Estado.MIRAR;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SwitchToAndar()
    {
        actions--;
        botoes.SetActive(false);
        mira.SetActive(false);
        clickInstructions.SetActive(true);
        currentState = Estado.ANDAR;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SwitchToStart()
    {
        botoes.SetActive(true);
        mira.SetActive(false);
        enemiesTxt.SetActive(false);
        clickInstructions.SetActive(false);
        currentState = Estado.START;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator SwitchToEnemiesTurn()
    {
        enemiesTxt.SetActive(true);
        mira.SetActive(false);
        botoes.SetActive(false);
        clickInstructions.SetActive(false);
        currentState = Estado.ENEMIES_TURN;
        Cursor.lockState = CursorLockMode.None;

        foreach (Enemy e in enemies)
        {
            yield return new WaitForSeconds(2f);
            print("atacou");
            e.Attack();
        }

        SwitchToStart();

    }
    public void SwitchToWin()
    {
        botoes.SetActive(false);
        mira.SetActive(false);
        winTxt.SetActive(true);
        currentState = Estado.WIN_STATE;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SwitchToLose()
    {
        botoes.SetActive(false);
        mira.SetActive(false);
        loseTxt.SetActive(true);
        currentState = Estado.LOSE_STATE;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}