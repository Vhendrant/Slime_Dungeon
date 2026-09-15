using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float moveSpeed = 2;
    private InputAction moveAction;
    private InputAction attackAction;
    public Animator animator;
    public GameObject slime;
    public GameObject sword; 
    private Animator swordAnimator; 
    private Vector2 lastDirection = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        moveAction.Enable();
        attackAction.Enable();

        //Instantiate(slime, transform.position, transform.rotation);
        swordAnimator = sword.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction == null) return;

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveValue.x, moveValue.y, 0);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
        animator.SetFloat("Speed", moveValue.sqrMagnitude);


        
        if(moveValue != Vector2.zero)
        {
            animator.SetFloat("MoveX", moveValue.x);
            animator.SetFloat("MoveY", moveValue.y);

            // For sword direction
            lastDirection = moveValue;
        }

        // For attack animation (moving arms)

        if (attackAction != null && attackAction.WasPressedThisFrame())
        {
            Debug.Log("Attack Pressed");
            rb2d.linearVelocity = Vector2.zero;
            animator.SetTrigger("Attack");

            swordAnimator.SetFloat("SideX", lastDirection.x);
            swordAnimator.SetFloat("SideY", lastDirection.y);
            swordAnimator.SetTrigger("Attack");
        }
    }
}
