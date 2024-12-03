using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopDefendingState : IState
{
    TroopSMBase troopSM;

    public TroopDefendingState(TroopSMBase mySM)
    {
        troopSM = mySM;
    }

    public void Exit()
    {

    }

    public void Start()
    {
        
    }

    public void Update()
    {
        if(troopSM.isHighlighted && Input.GetMouseButtonDown(0))
        {
            troopSM.TransitionState(troopSM.troopGoTo);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            troopSM.TransitionState(troopSM.troopFollow);
        }
        troopSM.hitColliders = Physics2D.OverlapCircleAll(troopSM.transform.position, 5f);
        foreach(BoxCollider2D collide in troopSM.hitColliders)
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
}
