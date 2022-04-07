using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 5f;

    [SerializeField] PlayerInputActions playerControls;
    Vector2 moveDirection = Vector2.zero;
    InputAction move;


    void Awake(){
        playerControls = new PlayerInputActions();
    }
    
    void OnEnable(){
        move = playerControls.Player.Move;
        move.Enable();
    }
    void OnDisable(){
        move.Disable();
    }

    void Update(){
        moveDirection = move.ReadValue<Vector2>();
    }
    void FixedUpdate(){
        rb.AddRelativeForce(0,moveDirection.y * moveSpeed,0);
        //rb.AddRelativeTorque(0,0,-moveDirection.x * turnSpeed);
        transform.Rotate(0,0,-moveDirection.x*turnSpeed,Space.Self);
    }
}
