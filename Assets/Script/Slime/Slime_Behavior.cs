using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Slime_Behavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public TextMeshPro text;
    public Animator animator;
    public float moveSpeed = 5;
    public Vector2 direction;
    public static event System.Action<bool> slimecountchange;
    public ISlimeState currentSlimeState {get; private set;}
    public slimeIdleState IdleState {get; private set;}
    public slimeMoveState MoveState {get; private set;}
    public slimeMultiplyState multiplyState {get; private set;}

    void Awake()
    {
        IdleState = new slimeIdleState(this);
        MoveState = new slimeMoveState(this);
        multiplyState = new slimeMultiplyState(this);
    }
    void Start()
    {
        ChangeState(IdleState);
        if (slimecountchange != null)
        {
            slimecountchange.Invoke(true); 
        }

    }
    
    public void ChangeState(ISlimeState newState)
    {
        if (currentSlimeState != null)
        {
            currentSlimeState.Exit();
        }
        currentSlimeState = newState;

        if (currentSlimeState != null)
        {
            currentSlimeState.Enter();
        }
    }

    private void OnDestroy() {
        if (slimecountchange != null)
        {
            slimecountchange.Invoke(false);           
        }

    }
    void Update()
    {
        if (currentSlimeState != null)
        {
            currentSlimeState.Update();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Movement.PlayerTransform != null)
            {
                direction = (Movement.PlayerTransform.position - transform.position).normalized;
            }
            else 
            {
                direction = Vector2.zero;
            }
            rb2d.AddForce(-direction * moveSpeed, ForceMode2D.Impulse);
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.Takedamage(1);
            }
        }
    }
}
