using UnityEngine;


public class CollisionHandling : MonoBehaviour
{
    Rigidbody rb;

    void Awake(){
        
        rb = GetComponent<Rigidbody>();
    }
    

    void OnCollisionEnter(Collision collision){

        switch (collision.gameObject.tag){
            case "Start":
                print("Start");
                break;
            case "End":
                print("End");
                break;
            case "Obstacle":
                print("OI, STOP TOUCHING ME!");
                break;
        }
    }


}
