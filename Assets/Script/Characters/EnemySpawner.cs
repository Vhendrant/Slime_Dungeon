using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Slime;
    public int spawnCount = 4; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Instantiate Slime
            Vector3 random = new Vector3(Random.Range(0.5f, 3f), Random.Range(0.5f, 3f), 0);
            Instantiate(Slime, Vector3.zero + random, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
