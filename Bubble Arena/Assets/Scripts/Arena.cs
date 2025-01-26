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

    int i = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        roundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoundManager>();
        currentPlayer = GameObject.FindGameObjectsWithTag("Player").Count();

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
