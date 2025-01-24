using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;

    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(10, 0, 0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        oldPosition = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 position = gameObject.transform.position;

        Vector3 vectorDirecteur = new Vector3(oldPosition.x - position.x,oldPosition.y - position.y, oldPosition.z - position.z);

        rb.AddForce(vectorDirecteur, ForceMode.Impulse);
        
    }
}
