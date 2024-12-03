using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TroopChargeEnemy : IState
{
    TroopSMBase troopSM;
    float distance;
    public TroopChargeEnemy(TroopSMBase mySM)
    {
        troopSM = mySM;
    }

    public void Exit()
    {
        
    }

    void IState.Start()
    {
        
    }

    void IState.Update()
    {
        if(troopSM.enemy == null)
        {
            troopSM.TransitionState(troopSM.troopDefending);
        }
        else
        {
            distance = Vector2.Distance(troopSM.transform.position, troopSM.enemy.transform.position);
                if(distance <= troopSM.attackRange)
            {
            Vector2 directionAway = (troopSM.transform.position - troopSM.enemy.transform.position).normalized;
            Vector2 holder = troopSM.enemy.transform.position;
            Vector2 newPosition = holder + directionAway * troopSM.attackRange;
            troopSM.agent.SetDestination(newPosition);
            
            }
            else
            {
            troopSM.agent.SetDestination(troopSM.enemy.transform.position);
            }
        }
        if(troopSM.isHighlighted && Input.GetMouseButtonDown(0))
        {
            troopSM.TransitionState(troopSM.troopGoTo);
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            troopSM.TransitionState(troopSM.troopFollow);
        }
    }
}
