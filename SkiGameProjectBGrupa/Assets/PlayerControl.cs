using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private float rotSpeed = 30, speed = 20;
    private Rigidbody rb;
    void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }

 
    void FixedUpdate()
    {

        Vector2 moveInput = move.ReadValue<Vector2>();

        transform.Rotate(0, -moveInput.x * rotSpeed * Time.fixedDeltaTime, 0);

        float turnAngle = Mathf.Abs(transform.localEulerAngles.y);

        float speedMult = Mathf.Cos(turnAngle * Mathf.Deg2Rad);
        
        rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);
        
        Debug.Log("turn angle: " + turnAngle);
    }
    

    
}
