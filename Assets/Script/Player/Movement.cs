using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float moveSpeed = 2;
    private InputAction moveAction;
    public Animator animator;
    public GameObject slime;
    public Vector2 moveValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();

        Vector3 random = new Vector3(Random.Range(1, 10), Random.Range(1, 10));

        Instantiate(slime, transform.position + random, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction == null) return;

        moveValue = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveValue.x, moveValue.y, 0);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
        animator.SetFloat("Speed", moveValue.sqrMagnitude);


        
        if(moveValue != Vector2.zero)
        {
            animator.SetFloat("MoveX", moveValue.x);
            animator.SetFloat("MoveY", moveValue.y);
        }
    }
}
