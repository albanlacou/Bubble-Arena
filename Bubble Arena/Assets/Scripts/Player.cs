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
    public float baseForce = 10f; // La force de base appliquée
    public float forceIncreaseRate = 1f; // Augmentation de la force par seconde

    private float accumulatedForce;

    private RoundManager roundManager;


    [SerializeField] private float vitesse = 150f; // Vitesse de déplacement
    // Start is called before the first frame update
    void Start()
    {
        accumulatedForce = baseForce;
        rb = gameObject.GetComponent<Rigidbody>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        roundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoundManager>();
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (roundManager.playerCanMove)
        {
            Vector3 position = gameObject.transform.position;
            vectorDirecteur = new Vector3(oldPosition.x - position.x, oldPosition.y - position.y, oldPosition.z - position.z);
            if (isPlayerOne)
            {
                mouvementHorizontal = Input.GetAxis("Horizontal");
                mouvementVertical = Input.GetAxis("Vertical");
            }
            else
            {
                mouvementHorizontal = Input.GetAxis("Player2Horizontal");
                mouvementVertical = Input.GetAxis("Player2Vertical");
            }
            oldPosition = gameObject.transform.position;
        }
        

        oldPosition = gameObject.transform.position;
        accumulatedForce += forceIncreaseRate * Time.deltaTime;


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
            rb.AddForce(collisionDirection * accumulatedForce, ForceMode.Impulse);



            
        }
        
       

    }

    void FixedUpdate()
    {
       
            rb.AddForce( new Vector3(mouvementHorizontal * speed, mouvementVertical*speed,0), ForceMode.Acceleration);

    }
}
