using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Arena : MonoBehaviour
{
    public int currentPlayer;

    public static Arena instance;

    private RoundManager roundManager;

    private GameObject lastPlayer;

    public List<Player> playerToReactive;

    public ScoreDisplay scoreDisplay;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        int tata = PlayerPrefs.GetInt("NbJoueurs");
        if(tata == 0) {
            tata = 2;
        }


        Player[] allPlayers = FindObjectsOfType<Player>();

        List<GameObject> playersToRemove = new List<GameObject>();

        // Identifier les joueurs � supprimer
        foreach (Player player in allPlayers)
        {
            if (player.NumeroPlayer > tata)
            {
                playersToRemove.Add(player.gameObject);
            }
        }

        // Supprimer les joueurs identifi�s
        foreach (GameObject playerObj in playersToRemove)
        {
            Debug.Log($"Suppression du joueur {playerObj.name} avec NumeroPlayer {playerObj.GetComponent<Player>().NumeroPlayer}");
            Destroy(playerObj);
        }
        
        currentPlayer = tata;
    }

    // Start is called before the first frame update
    void Start()
    {
        roundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoundManager>();

        

    }

    // Update is called once per frame
    void Update()
    {
    }

    

    void OnTriggerExit(Collider other)
    {
        //a changer

        Player player = other.gameObject.GetComponent<Player>();

        playerToReactive.Add(player);
        other.gameObject.SetActive(false);

        currentPlayer--;
        
        if (currentPlayer == 1)
        { 
            GameObject[] lastPlayers = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(lastPlayers.Length);

            foreach (GameObject p in lastPlayers)
            {
                if (p.activeSelf)
                {
                    p.GetComponent<Player>().pointPlayer++;
                    p.gameObject.transform.position = p.gameObject.GetComponent<Player>().spawnPoint;
                    ReactifAllPlayer();
                    scoreDisplay.scoreHUD();
                }
            }
            roundManager.ChangeRound();
            reInit();

        }
    }

    void ReactifAllPlayer()
    {
        Debug.Log(playerToReactive.Count());
        foreach (Player pR in playerToReactive) { 
            pR.gameObject.SetActive(true);
            pR.gameObject.transform.position = pR.gameObject.GetComponent<Player>().spawnPoint;
        }
    }


    public void reInit()
    {
        currentPlayer = GameObject.FindGameObjectsWithTag("Player").Count();
    }
}
