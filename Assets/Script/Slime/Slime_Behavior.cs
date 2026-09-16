using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Slime_Behavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject player;
    public Movement movement;
    private float moveSpeed = 5;
    private float timer = 0;
    public Animator animator;
    private bool isMoving;
    public float spawnTimer = 7.5f;
    public float Health = 5;
    public TextMeshPro text;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movement = player.GetComponent<Movement>();
        Health = 5;
        spawnTimer = 7.5f;
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
        multiply();

    }
    public void multiply()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {   
            spawnTimer = 7.5f;
            Instantiate(gameObject, transform.position, transform.rotation);

        }
        text.text = spawnTimer.ToString("F1");
    }
    public void died()
    {
        if(Health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            movement.health -= 1;
            movement.rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
            rb2d.AddForce(-direction * moveSpeed, ForceMode2D.Impulse);
        }
    }
}
