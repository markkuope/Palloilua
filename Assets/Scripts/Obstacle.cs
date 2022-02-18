using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed; // float (desimaaliluku) muuttuja liikkeen nopeus 

    // Update is called once per frame
    void Update()
    {
        //Este liikkuu x -suuntaan nopeudella moveSpeed
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);


        //Kun este on poissa ruudulta, tuhotaan se (s‰‰styy laskentatehoa)
        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }

    }
}
