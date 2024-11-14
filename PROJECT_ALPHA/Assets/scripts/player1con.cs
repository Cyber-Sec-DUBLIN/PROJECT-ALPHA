using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update

    public float jumpforce = 140; 
    public float gravitymod = 5;
    public bool isGround = true;
    public int speed = 20;
    public float AD;
    public int canmove = 1; //Basically this will be used to turn off the players movement when they shouldn't be able to move (i.e during attacks)

    public int HEALTHPOINTS = 100; //heatlth points
    
    public GameObject fireObj;
    public GameObject punchObj;
    public GameObject player; //the gameobject for the player
    
    private Rigidbody playerRb; //rigidbody 

    void Start()
    {
         playerRb = GetComponent<Rigidbody>();   
        Physics.gravity *=gravitymod;
    }

    // Update is called once per frame
    async void Update() //the task.delay function only works if the method is async
    {

        if (HEALTHPOINTS == 0) {
            Destroy(player);
            Debug.Log("Player 2 WINS. and by extention player 1 is dead");
        }
    AD = Input.GetAxis("Horizontal"); //telling it hoirzontal puts movement keys on a and d 
   
    transform.Translate(Vector3.right * speed * Time.deltaTime * AD * canmove); //this single line controls movement. Wonderful isn't it

    if (Input.GetKeyDown(KeyCode.Space) && isGround) {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isGround = false;  
        }
       if (isGround == false) { 
        speed = 10;
       }
       else {
        speed = 20;
       }
       //In real life it is incredibly difficult to change the direction whilst in the air. This carries over to video game as well



        if (Input.GetKeyDown(KeyCode.E))  { 
            if (canmove == 1) {
            canmove = 0; 
        Instantiate(fireObj, transform.position + new Vector3(3,0,0), fireObj.transform.rotation); 
        await Task.Delay(1000); //after seconds
        canmove = 1; 
        }
        } 

        if (Input.GetKeyDown(KeyCode.R))  { 
            if (canmove == 1) {
            canmove = 0; 
        Instantiate(punchObj, transform.position + new Vector3(3,0,0), punchObj.transform.rotation); 
        await Task.Delay(400); //after seconds
        canmove = 1; 
        }
        
        } 
        //When the player presses E and canmove is 1, set canmove to 0 to stop movement and spamming the move rapidly, create the fireball object, wait a second, then set canmove to 1
        //Also you may have noticed the check for canmove being 1 is inside the keycode check. This is what we in the business call a nested IF statement since the keycode thing doesn't
        //Like if if you try apply more logic stuff to it
  
        //Debug.Log(HEALTHPOINTS);
        }

        private void OnCollisionEnter(Collision collision) { //resets isground when on ground
        isGround = true;
        
        if (collision.gameObject.CompareTag("PUNCHING BAG")) { //This part kinda annoyed me since I thought CompareTag mean the objects name. 
            HEALTHPOINTS = HEALTHPOINTS - 25;
        }
        }
}

