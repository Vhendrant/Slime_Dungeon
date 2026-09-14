using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float moveSpeed = 2;
    private InputAction moveAction;
    private InputAction attackAction;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        moveAction.Enable();
        attackAction.Enable();
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

        }

        if (attackAction != null && attackAction.WasPressedThisFrame())
        {
            Debug.Log("Attack Pressed");
        }
    }
}
