using UnityEngine;

public class Slime_Behavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject player;
    private float moveSpeed = 5;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        }
    }
}
