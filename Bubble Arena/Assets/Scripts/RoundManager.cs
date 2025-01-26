using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    //RAF:
    //TOFO: ajouter les animation de Raphael
    //FOTO: ajouter le controle de volumr
    //POTO: Relier les scenes
    //TODO ajouter une fin
    //polish ?cran de s?l?ction des persos
    //ajouter un nb de rounds
    //d?sactiver les scores pour les joueurs non pr?sent
    public int round = 0;

    [SerializeField]
    private TMP_Text roundText;

    private SoundManager soundManager;

    public bool playerCanMove = false;

    [SerializeField]
    private GameObject upBlackBar;


    [SerializeField]
    private GameObject downBlackBar;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        ChangeRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeRound()
    {
        playerCanMove = false;
        upBlackBar.transform.DOMoveY(4.75f, 1);
        downBlackBar.transform.DOMoveY(-4.75f, 1);
        roundText.enabled = true;
        round++;
        roundText.text = "Round: " + round;
        soundManager.playRound(round);
        
        Invoke(nameof(startRound), 3f);

    }

    public void startRound()
    {
 
        upBlackBar.transform.DOMoveY(7,1);
        downBlackBar.transform.DOMoveY(-7, 1);
        roundText.enabled = false;
        playerCanMove = true;
    }
}
