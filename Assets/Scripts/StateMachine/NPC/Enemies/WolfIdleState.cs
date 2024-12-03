using UnityEngine;

public class WolfIdleState : EnemyIdleState
{
    public WolfIdleState(EnemySMBase enemyStateMachine) : base(enemyStateMachine)
    {
    }

    protected override void startIdle()
    {
        base.startIdle();
        Debug.Log("IM A WOLF, RAAAAAAAAAAAAAAAAAAAAA");
        {
            
        }
    }
}
