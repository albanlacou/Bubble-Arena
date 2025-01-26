using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 1;

    private Rigidbody rb;

    private Vector3 oldPosition;

    private float mouvementHorizontal;

    private float mouvementVertical;

    public bool isPlayerOne = false;

    public Vector3 vectorDirecteur;

    private CameraShake shake;

    private SoundManager soundManager;

    [SerializeField]
    public float cooldownTime = 3f;

    private float newSwitchTime = 0f;


    [SerializeField]
    public float baseForce = 10f; // La force de base appliquée
    public float forceIncreaseRate = 1f; // Augmentation de la force par seconde

    private float accumulatedForce;

    private RoundManager roundManager;

    public short pointPlayer = 0;

    public Vector3 spawnPoint;

    private float dash;


    public bool toto = true;


    [SerializeField] private float vitesse = 150f; // Vitesse de déplacement
    // Start is called before the first frame update
    void Start()
    {
        accumulatedForce = baseForce;
        rb = gameObject.GetComponent<Rigidbody>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        roundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoundManager>();
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();  
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (roundManager.playerCanMove)
        {
            Vector3 position = gameObject.transform.position;
            vectorDirecteur = new Vector3(position.x - oldPosition.x, position.y - oldPosition.y, position.z - oldPosition.z);
            if (isPlayerOne)
            {
                mouvementHorizontal = Input.GetAxis("Horizontal");
                mouvementVertical = Input.GetAxis("Vertical");
                dash = Input.GetAxis("PlayerOneDash");
            }
            else
            {
                mouvementHorizontal = Input.GetAxis("Player2Horizontal");
                mouvementVertical = Input.GetAxis("Player2Vertical");
            }
            oldPosition = gameObject.transform.position;

           
            accumulatedForce += forceIncreaseRate * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        

        


    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.playExplosion();
        shake.shakeDuration = 0.2f;

        if (collision.gameObject.GetComponent<Player>())
        {
            // Calculer la direction opposée
            Vector3 collisionDirection = transform.position - collision.transform.position;
            collisionDirection.Normalize(); // Normaliser pour obtenir une direction unitaire

            
            // Appliquer une force opposée
            rb.AddForce(collisionDirection * Mathf.Max(accumulatedForce, 15), ForceMode.Impulse);
            
        }
        
       

    }

    void FixedUpdate()
    {
        
        if (roundManager.playerCanMove)
        {
            rb.AddForce(new Vector3(mouvementHorizontal * speed, mouvementVertical * speed, 0), ForceMode.Acceleration);

            Debug.Log(Time.time >= newSwitchTime);
            if (dash > 0 && Time.time >= newSwitchTime)
            {
                Debug.Log("raelz,rdlmzae,dmlz");
                rb.AddForce(vectorDirecteur.normalized * 10f, ForceMode.Impulse);
                newSwitchTime = Time.time + cooldownTime;

            }
           
        }

    }
}
