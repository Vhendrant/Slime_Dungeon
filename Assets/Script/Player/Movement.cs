using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float moveSpeed = 2.5f;
    private InputAction moveAction;
    public Animator animator;
    public Vector2 moveValue;
    public AimDirection aim;
    public static Transform PlayerTransform;

    void Awake()
    {
        PlayerTransform = this.transform;
    }
    void ODestroy()
    {
        PlayerTransform = null;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction == null) return;

        moveValue = moveAction.ReadValue<Vector2>();
        animator.SetFloat("Speed", moveValue.sqrMagnitude);
        animator.SetFloat("MoveX", aim.aimDirection.x);
        animator.SetFloat("MoveY", aim.aimDirection.y);
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = moveValue * moveSpeed;
    }
}
