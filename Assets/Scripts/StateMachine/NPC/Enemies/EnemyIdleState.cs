using UnityEngine;

public class EnemyIdleState : IState
{
    private GameObject player;
    EnemySMBase enemySM;

    float timer;

    private float randomAngle;
    private float randomAngle2;
    private float distance;

    public EnemyIdleState(EnemySMBase enemyStateMachine)
    {
        enemySM = enemyStateMachine;
    }
    void IState.Start()
    {
        //startIdle();
        distance = Vector2.Distance(enemySM.startPosition, enemySM.transform.position);
        if(distance >= enemySM.wanderDistance)
        {
            enemySM.TransitionState(enemySM.enemyReturn);
        }
        timer = Random.Range(0f, enemySM.timeBtwnIdle);
    }

    void IState.Update()
    {
        //updateIdle();
        if (enemySM.target == null) return;
        //calculates distance and if player is close enough, chase state
        distance = Vector2.Distance(enemySM.transform.position, enemySM.target.transform.position);
        if(distance <= enemySM.startChaseDistance)
        {
            enemySM.chasingPlayer = true;
            enemySM.TransitionState(enemySM.enemyChase);
        }
        //generates random vectors when the timer isnt hit
        if(timer < enemySM.timeBtwnIdle)
        {
            timer+= Time.deltaTime;
            randomAngle = Random.Range(-360, 360);
            randomAngle2 = Random.Range(-360, 360);
        }
        //when the timer runs out, move at the random angle
        if( timer >= enemySM.timeBtwnIdle && timer <(enemySM.timeSpentIdling + enemySM.timeBtwnIdle))
        {
            Vector2 idleMove = new Vector2(randomAngle, randomAngle2);
            enemySM.transform.position = Vector2.MoveTowards(enemySM.transform.position, idleMove, enemySM.idleSpeed * Time.deltaTime * 0.75f);
            timer+= Time.deltaTime;
        }
        //continue to move for a set amount of time, then reset timer
        if(timer >= enemySM.timeSpentIdling + enemySM.timeBtwnIdle)
        {
            timer = Random.Range(0f, enemySM.timeBtwnIdle);
        }
        enemySM.hitColliders = Physics2D.OverlapCircleAll(enemySM.transform.position, 5f);
        foreach(BoxCollider2D collide in enemySM.hitColliders)
        {
            
            enemySM.troop = collide.GetComponentInParent<TroopSMBase>();
            if(enemySM.troop != null)
            {
                enemySM.chasingPlayer = false;
                enemySM.troop = enemySM.troop.GetComponent<TroopSMBase>();
                enemySM.TransitionState(enemySM.enemyChase);
                break;
            }
        }
    }

    void IState.Exit()
    {
        exitIdle();
    }

    protected virtual void startIdle() {
        
    }

    protected virtual void updateIdle() {
        
    }

    protected virtual void exitIdle() {

    }

}