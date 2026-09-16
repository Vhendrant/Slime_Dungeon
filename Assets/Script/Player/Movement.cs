using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float moveSpeed = 3.5f;
    private InputAction moveAction;
    public Animator animator;
    public GameObject slime;
    public Vector2 moveValue;
    public Vector2 aimDirection;
    public int health = 10;
    public Manager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();

        Vector3 random = new Vector3(Random.Range(1, 3), Random.Range(1, 3), 0);

        Instantiate(slime, transform.position + random, transform.rotation);
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

        if (health <= 0)
        {
            manager.GameOver();
            Destroy(gameObject);
        }
    }
}
