using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tutoriais;
    private int index;

    public void NextTutorial()
    {
       tutoriais[index].SetActive(false);
       if (index < tutoriais.Length - 1)
       {
           index++;
           tutoriais[index].SetActive(true);
       }
    }
}
