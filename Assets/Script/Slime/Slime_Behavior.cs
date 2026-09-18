using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Slime_Behavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject player;
    private float moveSpeed = 5;
    private float timer = 0;
    public Animator animator;
    public float spawnTimer;
    public TextMeshPro text;
    public bool isOver = false;
    public GameObject manager;
    public static event System.Action<bool> slimecountchange;
    private int lastsecond = -1;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnTimer = 8f;
        manager = GameObject.FindWithTag("Manager");
        slimecountchange.Invoke(true);
    }
    private void OnDestroy() {
        slimecountchange.Invoke(false);
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
            Vector2 direction = (player.transform.position - transform.position).normalized;
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
            spawnTimer = 8f;
            lastsecond = -1;
            Instantiate(gameObject, transform.position, transform.rotation);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb2d.AddForce(-direction * moveSpeed, ForceMode2D.Impulse);
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.Takedamage(1);
            }
        }
    }
}
