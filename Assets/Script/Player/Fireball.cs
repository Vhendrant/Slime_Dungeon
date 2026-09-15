using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slime"))
        {
            Collider2D col = GetComponent<Collider2D>();
            if (col != null) col.enabled = false;

            animator.SetTrigger("Boom");
            speed = 0;
            Destroy(gameObject, 0.66f);

            Slime_Behavior slime_Behavior = collision.GetComponent<Slime_Behavior>();
            if (slime_Behavior != null)
            {
                slime_Behavior.Health -= 1; 
                slime_Behavior.died();
            }

        }
    }
}
