using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public Vector3 spawnPosition;
    private GameObject destroyPlayer;
    public short pointPlayer1 = 0;
    public short pointPlayer2 = 0;

    public static Arena instance;

    private RoundManager roundManager;

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

}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        roundManager.ChangeRound();

        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            destroyPlayer = other.gameObject;
            Destroy(other.gameObject);
        }

        if (destroyPlayer.CompareTag("Player1"))
        {
            Instantiate(Player1, new Vector3(2.22f, 2.07f, -0.5f), Quaternion.identity);
            pointPlayer2++;
        }
        if (destroyPlayer.CompareTag("Player2"))
        {
            Instantiate(Player2, new Vector3(-2.17f, -1.38f, -0.5f), Quaternion.identity);
            pointPlayer1++;
        }
    }
}
