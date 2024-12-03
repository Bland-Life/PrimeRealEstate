using UnityEngine;

public class EnemyReturnHome : IState
{
    EnemySMBase enemySM;
    private float distanceHome;
    private float distancePlayer;

    public EnemyReturnHome(EnemySMBase enemyStateMachine)
    {
        enemySM = enemyStateMachine;
    }

    void IState.Start()
    {
        
    }

    void IState.Update()
    {
        enemySM.agent.SetDestination(enemySM.startPosition);
        distanceHome = Vector2.Distance(enemySM.transform.position, enemySM.startPosition);
        distancePlayer = Vector2.Distance(enemySM.transform.position, enemySM.target.transform.position);
        if(distanceHome <= 1)
        {
            enemySM.TransitionState(enemySM.enemyIdle);
        }
        else if(distancePlayer <= enemySM.startChaseDistance)
        {
            enemySM.TransitionState(enemySM.enemyChase);
        }
    }

    void IState.Exit()
    {

    }
}
