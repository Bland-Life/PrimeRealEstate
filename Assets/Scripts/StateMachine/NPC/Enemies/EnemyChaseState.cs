using UnityEngine;

public class EnemyChaseState : MonoBehaviour,  IState
{   
    
    EnemySMBase enemySM;
    private float distance;

    public EnemyChaseState(EnemySMBase enemyStateMachine)
    {
        enemySM = enemyStateMachine;
    } 

    void IState.Start()
    {

    }

    // chases the player until player is out of distance
    void IState.Update()
    {
        if(enemySM.chasingPlayer)
        {
            enemySM.agent.SetDestination(enemySM.target.transform.position);
            distance = Vector2.Distance(enemySM.transform.position, enemySM.target.transform.position);
            if(distance > enemySM.maxChaseDistance)
            {
                enemySM.TransitionState(enemySM.enemyIdle);
            }
        }
        else
        {
            enemySM.agent.SetDestination(enemySM.troop.transform.position);
            if(enemySM.troop == null)
            {
                enemySM.TransitionState(enemySM.enemyIdle);
            }
        }
    }

    void IState.Exit()
    {

    }
}
