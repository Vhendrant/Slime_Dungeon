using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float moveSpeed = 3.5f;
    private InputAction moveAction;
    public Animator animator;
    public Vector2 moveValue;
    public Vector2 aimDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 global_mouse = Mouse.current.position.ReadValue();
        Vector2 local_mouse = Camera.main.ScreenToWorldPoint(global_mouse);
        aimDirection = (local_mouse - (Vector2)transform.position).normalized;

        if (moveAction == null) return;

        moveValue = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveValue.x, moveValue.y, 0);
        rb2d.linearVelocity = move * moveSpeed;
        animator.SetFloat("Speed", moveValue.sqrMagnitude);

        animator.SetFloat("MoveX", aimDirection.x);
        animator.SetFloat("MoveY", aimDirection.y);
    }
}
