using UnityEngine;

public class slimeIdleState: ISlimeState
{
    private Slime_Behavior slime_Behavior;
    public float spawnTimer = 8f;
    public float initialSpawnTimer = 8f;
    public int lastsecond = -1;
    public float timer = Random.Range(0.5f, 4.5f);
    public slimeIdleState(Slime_Behavior slime)
    {
        slime_Behavior = slime;
    }
    public void Enter()
    {
    }
    public void Update()
    {
        // Multiplying Timer
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            int currentSecond = Mathf.CeilToInt(spawnTimer);
            if (currentSecond != lastsecond)
            {
                lastsecond = currentSecond;
                slime_Behavior.text.text = lastsecond.ToString();
            }
        }
        else
        {   
            spawnTimer = initialSpawnTimer;
            lastsecond = -1;
            slime_Behavior.ChangeState(slime_Behavior.multiplyState);
        }
        
        // Hopping Timer
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = Random.Range(3.8f, 4.5f);
            slime_Behavior.ChangeState(slime_Behavior.MoveState);
        }
    }
    public void FixedUpdate()
    {

    }
    public void Exit()
    {
        
    }
}
