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
    private bool isMoving;
    public float spawnTimer;
    public TextMeshPro text;
    public bool isOver = false;
    public GameObject manager;
    public Manager managerClass;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnTimer = 8f;
        manager = GameObject.FindWithTag("Manager");
        managerClass = manager.GetComponent<Manager>();
        managerClass.count += 1;
    }
    private void OnDestroy() {
        managerClass.count -= 1;
    }
    void Update()
    {
        float target = 4; 

        if (timer < target)
        {
            timer += Time.deltaTime;
            isMoving = false;
        }
        else
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
            timer = 0;
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
            isMoving = true;
        }
        animator.SetBool("Moving", isMoving);
        if (!isOver)
        {
            multiply();
        }
    }
    public void multiply()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {   
            spawnTimer = 8f;
            Instantiate(gameObject, transform.position, transform.rotation);

        }
        text.text = spawnTimer.ToString("F1");
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
