using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class VillagerIdleState : IState
{
    float timer = 0;
    private float randomAngle;
    private float randomAngle2;
    VillagerSM villagerSM;

    public VillagerIdleState (VillagerSM mySM)
    {
        villagerSM = mySM;
    }

    void IState.Start()
    {

    }

    void IState.Update()
    {
        if(timer < villagerSM.timeBtwnIdle)
        {
            timer += Time.deltaTime;
            randomAngle = Random.Range(-360, 360);
            randomAngle2 = Random.Range(-360, 360);
        }
        if(timer >= villagerSM.timeBtwnIdle && timer < (villagerSM.timeBtwnIdle + villagerSM.timeSpentIdling))
        {
            Vector2 idleMove = new Vector2(randomAngle, randomAngle2);
            villagerSM.villager.transform.position = Vector2.MoveTowards(villagerSM.villager.transform.position, idleMove, villagerSM.idleSpeed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        if(timer > (villagerSM.timeBtwnIdle + villagerSM.timeSpentIdling))
        {
            timer = 0;
        }
    }

    void IState.Exit()
    {
        
    }
}
