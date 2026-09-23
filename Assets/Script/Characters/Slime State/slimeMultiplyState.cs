using UnityEngine;

public class slimeMultiplyState: ISlimeState
{
    private Slime_Behavior slime_Behavior;
    public slimeMultiplyState(Slime_Behavior slime)
    {
        slime_Behavior = slime;
    }
    public void Enter()
    {
        GameObject.Instantiate(slime_Behavior.gameObject, slime_Behavior.transform.position, slime_Behavior.transform.rotation);
        slime_Behavior.ChangeState(slime_Behavior.IdleState);
    }
    public void Update()
    {
        
    }
    public void FixedUpdate()
    {
        
    }
    public void Exit()
    {
        
    }
}
