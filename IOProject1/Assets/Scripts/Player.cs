
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private InputAction moveAction;
    
   

    private void Awake()
    {
        
       
    }

    private void Update()
    {

        Move();

    }

    private void Move()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        var adjustedMove = new Vector3(moveValue.x, 0, moveValue.y);
        
        transform.position += (speed * Time.deltaTime * adjustedMove);
        //transform.Translate(transform.forward * speed * Time.deltaTime * moveValue);
    }
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }


}