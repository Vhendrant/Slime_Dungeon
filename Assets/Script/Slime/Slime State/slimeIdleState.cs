using UnityEngine;

public class slimeIdleState: ISlimeState
{
    private Slime_Behavior slime_Behavior;
    public float spawnTimer;
    public int lastsecond = -1;
    public float timer;
    public slimeIdleState(Slime_Behavior slime)
    {
        slime_Behavior = slime;
        spawnTimer = slime_Behavior.slimeData.initialSpawnTimer;
        timer = Random.Range(slime_Behavior.slimeData.minimumHoptimer, slime_Behavior.slimeData.maximumHoptimer);
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
            spawnTimer = slime_Behavior.slimeData.initialSpawnTimer;
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
            timer = Random.Range(slime_Behavior.slimeData.minimumHoptimer, slime_Behavior.slimeData.maximumHoptimer);
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
