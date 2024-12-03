using UnityEngine;
using UnityEngine.InputSystem;

public class TroopFollowState : IState
{
    TroopSMBase troopSM;
    public TroopFollowState(TroopSMBase mySM)
    {
        troopSM = mySM;
    }

    void IState.Start()
    {

    }

    void IState.Update()
    {
        troopSM.agent.SetDestination(troopSM.target.transform.position);
        if(troopSM.isHighlighted && Input.GetMouseButtonDown(0))
        {
            troopSM.TransitionState(troopSM.troopGoTo);
        }
        troopSM.hitColliders = Physics2D.OverlapCircleAll(troopSM.transform.position, 5f);
        foreach(Collider2D collide in troopSM.hitColliders)
        {
            troopSM.enemy = collide.GetComponentInParent<EnemySMBase>();
            if(troopSM.enemy != null)
            {
                troopSM.enemy = troopSM.enemy.GetComponent<EnemySMBase>();
                troopSM.TransitionState(troopSM.troopCharge);
                break;
            }
        }
    }

    void IState.Exit()
    {

    }
}
