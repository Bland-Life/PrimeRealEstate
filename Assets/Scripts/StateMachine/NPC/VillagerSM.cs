using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class VillagerSM : StateMachine
{
    public VillagerIdleState villagerIdle {get; private set;}
    public GameObject villager;

    public float timeBtwnIdle = 3f;
    public float timeSpentIdling = 2f;
    public float idleSpeed = 1f;

    public VillagerSM()
    {
        villagerIdle = new VillagerIdleState(this);
        currentState = villagerIdle;
    }

}
