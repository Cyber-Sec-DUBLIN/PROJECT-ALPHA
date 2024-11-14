using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class forward : MonoBehaviour
{

    public int speed = 10;
    public GameObject Object;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    async void Update()
    { //ADD DESTROY FUNCTION WITH DELAY LATER. NOT WITH AN IF STATEMENT
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        await Task.Delay(1400); 
        Destroy(Object);

    }

    
      private void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject.CompareTag("PUNCHING BAG")) { 
           Destroy(Object);
        }
    
        }

    
}


