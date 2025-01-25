using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 1;

    public Rigidbody rb;

    private Vector3 oldPosition;

    public Vector3 force;

    private float mouvementHorizontal;

    private float mouvementVertical;

    public bool isPlayerOne = false;

    public Vector3 vectorDirecteur;

    public Vector3 oldVelocity;

    [SerializeField] private float vitesse = 150f; // Vitesse de déplacement
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
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

        oldVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            // Calculer la direction opposée
            Vector3 collisionDirection = transform.position - collision.transform.position;
            collisionDirection.Normalize(); // Normaliser pour obtenir une direction unitaire
            Vector3 relativeVelocity = collision.relativeVelocity;
            float test = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);
            Debug.Log(isPlayerOne +" : "+ rb.velocity.magnitude);

            
            // Appliquer une force opposée
            rb.AddForce(collisionDirection * 6, ForceMode.Impulse);


            
        }
        
       

    }

    void FixedUpdate()
    {
       
            rb.AddForce( new Vector3(mouvementHorizontal * speed, mouvementVertical*speed,0), ForceMode.Acceleration);
           
       
        
        
    }
}
