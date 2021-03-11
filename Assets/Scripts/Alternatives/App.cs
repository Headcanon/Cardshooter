using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public Model model;
    public View view;
    public Controller controller;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

public class Element : MonoBehaviour
{
    public App app
    {
        get { return FindObjectOfType<App>(); }
    }
}

public static class ExtendEstado
{
    public static bool Comparar(this Estado esteEstado, Estado estadoAComparar)
    {
        if (esteEstado == estadoAComparar) return true;
        else return false;
    }
}