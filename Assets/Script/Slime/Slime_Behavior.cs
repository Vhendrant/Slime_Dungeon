using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Slime_Behavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float moveSpeed = 5;
    private float timer = 0;
    public Animator animator;
    public float spawnTimer;
    public float initialSpawnTimer = 8f;
    public TextMeshPro text;
    public bool isOver = false;
    public static event System.Action<bool> slimecountchange;
    private int lastsecond = -1;
    public Vector2 direction;

    void Start()
    {
        spawnTimer = initialSpawnTimer;
        if (slimecountchange != null)
        {
            slimecountchange.Invoke(true); 
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
        if (!isOver)
        {
            multiply();
        }
    }
    
    void FixedUpdate()
    {        
        float target = 4; 
        if (timer < target)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (Movement.PlayerTransform != null)
            {
                direction = (Movement.PlayerTransform.position - transform.position).normalized;
            }
            else 
            {
                direction = Vector2.zero;
            }
            rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
            timer = 0;
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
            animator.SetTrigger("Moving");
        }
    }
    public void multiply()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            int currentSecond = Mathf.CeilToInt(spawnTimer);
            if (currentSecond != lastsecond)
            {
                lastsecond = currentSecond;
                text.text = lastsecond.ToString();
            }
        }
        else
        {   
            spawnTimer = initialSpawnTimer;
            lastsecond = -1;
            Instantiate(gameObject, transform.position, transform.rotation);

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
