using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rb; // Rigidbody tyyppinen muuttuja rb
    public float jumpForce; // Playerin hyppyvoima, desimaaliluku, julkinen muuttuja

    public bool gameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // rb saa PLayerin Rigidbodyn arvot
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // jos kosketusnäyttöä kosketetaan tai hiiren vasenta näppäintä painetaan
        if (Input.GetMouseButtonDown(0))
        {
            //Player liikkuu ylöspäin nopeudella jumpForce
            rb.velocity = Vector3.up * jumpForce;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            gameOver = true;
            GameManager.instance.Restart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "scoreChecker")
        {
            GameManager.instance.ScoreUp();
            
        }
    }


}
