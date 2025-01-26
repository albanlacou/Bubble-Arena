using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Linq;


public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreP1;
    public TMP_Text scoreP2;
    public TMP_Text scoreP3;
    public TMP_Text scoreP4;
    [SerializeField] public Arena Arena;
    public int nbPlayers = 0;


    // Start is called before the first frame update
    void Start()
    {
        scoreHUD();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void scoreHUD()
    {
        GameObject[] lastPlayers = GameObject.FindGameObjectsWithTag("Player");
        nbPlayers = lastPlayers.Count();

        switch (nbPlayers){
            case 4:
                scoreP1.text = "Score Player 1 : " + lastPlayers[0].GetComponent<Player>().pointPlayer.ToString();
                scoreP2.text = lastPlayers[1].GetComponent<Player>().pointPlayer.ToString()+" : Score Player 2";
                scoreP3.text = "Score Player 3 : " + lastPlayers[2].GetComponent<Player>().pointPlayer.ToString();
                scoreP4.text = lastPlayers[3].GetComponent<Player>().pointPlayer.ToString() + " : Score Player 4";
                break;
            case 3:
                scoreP1.text = "Score Player 1 : " + lastPlayers[0].GetComponent<Player>().pointPlayer.ToString();
                scoreP2.text = "Score Player 2 : " + lastPlayers[1].GetComponent<Player>().pointPlayer.ToString();
                scoreP3.text = lastPlayers[2].GetComponent<Player>().pointPlayer.ToString() + " : Score Player 3";
                break;
            case 2:
                scoreP1.text = "Score Player 1 : " + lastPlayers[0].GetComponent<Player>().pointPlayer.ToString();
                scoreP2.text = "Score Player 2 : " + lastPlayers[1].GetComponent<Player>().pointPlayer.ToString();
                break;

        }
    }

    //public void checkScore()
    //{
    //    GameObject[] lastPlayers = GameObject.FindGameObjectsWithTag("Player");
    //    nbPlayers = lastPlayers.Count();

    //    switch (nbPlayers)
    //    {
    //        case 4:
    //            scoreP1.text = lastPlayers[0].GetComponent<Player>().pointPlayer.ToString();
    //            scoreP2.text = lastPlayers[1].GetComponent<Player>().pointPlayer.ToString();
    //            scoreP3.text = lastPlayers[2].GetComponent<Player>().pointPlayer.ToString();
    //            scoreP4.text = lastPlayers[3].GetComponent<Player>().pointPlayer.ToString();
    //            break;
    //        case 3:
    //            scoreP1.text = lastPlayers[0].GetComponent<Player>().pointPlayer.ToString();
    //            scoreP2.text = lastPlayers[1].GetComponent<Player>().pointPlayer.ToString();
    //            scoreP3.text = lastPlayers[2].GetComponent<Player>().pointPlayer.ToString();
    //            break;
    //        case 2:
    //            scoreP1.text = lastPlayers[0].GetComponent<Player>().pointPlayer.ToString();
    //            scoreP2.text = lastPlayers[1].GetComponent<Player>().pointPlayer.ToString();
    //            break;

    //    }
    //}
}
 