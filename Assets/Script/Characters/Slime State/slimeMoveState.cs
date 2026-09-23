using UnityEngine;

public class slimeMoveState : ISlimeState
{
    private Slime_Behavior slime_Behavior;
    public slimeMoveState(Slime_Behavior slime)
    {
        slime_Behavior = slime;
    }
    public void Enter()
    {
        if (Movement.PlayerTransform != null)
        {
            slime_Behavior.direction = (Movement.PlayerTransform.position - slime_Behavior.transform.position).normalized;
        }
        else 
        {
            slime_Behavior.direction = Vector2.zero;
        }
        slime_Behavior.rb2d.AddForce(slime_Behavior.direction * slime_Behavior.moveSpeed, ForceMode2D.Impulse);
        slime_Behavior.animator.SetFloat("MoveX", slime_Behavior.direction.x);
        slime_Behavior.animator.SetFloat("MoveY", slime_Behavior.direction.y);
        slime_Behavior.animator.SetTrigger("Moving");
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
