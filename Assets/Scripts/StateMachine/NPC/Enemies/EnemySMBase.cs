using UnityEngine;
using UnityEngine.AI;

public class EnemySMBase : StateMachine
{
    public NavMeshAgent agent;
    public GameObject target;

    public int moveSpeed = 3;
    public int maxChaseDistance = 20;
    public int startChaseDistance = 5;
    public int wanderDistance = 10;
    public float timeBtwnIdle = 3f;
    //time spent idle walking
    public float timeSpentIdling = 2f;
    public float idleSpeed = 2f;
    public Vector2 startPosition;
    public Collider2D[] hitColliders;
    public TroopSMBase troop;
    public bool chasingPlayer = false;

    public EnemyIdleState enemyIdle {get; protected set;}
    public EnemyChaseState enemyChase {get; protected set;}
    public EnemyReturnHome enemyReturn {get; protected set;}


    public EnemySMBase() {
        enemyIdle = new EnemyIdleState(this);
        enemyChase = new EnemyChaseState(this);
        enemyReturn = new EnemyReturnHome(this);
        currentState = enemyIdle;
    }

    protected override void Init()
    {
        this.startPosition = this.transform.position;
        this.agent = this.GetComponent<NavMeshAgent>();
        this.agent.updateRotation = false;
        this.agent.updateUpAxis = false;
    }
}
