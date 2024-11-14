using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUNCHBAG : MonoBehaviour
{ //THIS SCRIPT AND THE PUNCHING BAG OBJECT ONLY EXIST TO SHOW OFF THAT THE ATTACKS WORK AND THAT THE PLAYER CAN BE KILLED
    public int health = 100; 
    public GameObject bagObject;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MAKE SURE TO READ THE README FILE");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
        Destroy(bagObject);
        Debug.Log("PUNCHING BAG DOWN");
        }

       
    
       
    }

      private void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject.CompareTag("PUNCH")) { 
           health = health - 10;
        }
        else if (collision.gameObject.CompareTag("FIREBALL")) {
            health = health - 23;
        }
        }

    
}
