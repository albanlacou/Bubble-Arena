using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int nbPlayer = 0;

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
        if(round != 5)
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
        else
        {
            playerCanMove = false;
            Invoke(nameof(savedData), 0.5f);
        }
       

    }

    public void startRound()
    {
 
        upBlackBar.transform.DOMoveY(7,1);
        downBlackBar.transform.DOMoveY(-7, 1);
        roundText.enabled = false;
        playerCanMove = true;
    }

    public void savedData()
    {
        GameObject[] listPlayers = GameObject.FindGameObjectsWithTag("Player");

        nbPlayer = 0; // R?initialiser le compteur de joueurs
        foreach (GameObject p in listPlayers)
        {
            Player player = p.GetComponent<Player>();
            if (player != null)
            {
                nbPlayer++;
                // Sauvegarder les donn?es du joueur
                PlayerPrefs.SetInt("PlayerNumber" + nbPlayer, player.NumeroPlayer); // Num?ro du joueur
                PlayerPrefs.SetString("PlayerScore" + nbPlayer, player.pointPlayer.ToString()); // Score du joueur
                Debug.Log("PlayerScore" + nbPlayer+" : "+player.pointPlayer.ToString());
            }
        }
        PlayerPrefs.SetInt("nbPlayer", nbPlayer);
        SceneManager.LoadScene("ScoreMenu");
    }
}
