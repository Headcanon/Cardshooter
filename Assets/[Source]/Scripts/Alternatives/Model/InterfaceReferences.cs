using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InterfaceReferences : MonoBehaviour
{
    [Header("Game objects")]
    public GameObject playerInfo;
    public GameObject botoes;
    public GameObject mira;
    public GameObject enemiesObj;
    public GameObject clickInstructionsTxt;
    public GameObject walkInstructionsTxt;
    public GameObject winTxt;
    public GameObject loseTxt;
    public GameObject deck;

    [Header("Text mesh pro")]
    public TextMeshProUGUI healthTxt;
    public TextMeshProUGUI actionsTxt;
    public TextMeshProUGUI ammoTxt;
    public TextMeshProUGUI enemiesTxt;

    [Header("Images")]
    public Image DamageIndicator;
    public Image ShieldIndicator;
}
