using UnityEngine;
using UnityEngine.AI;

public class TroopSMBase : StateMachine
{
    public NavMeshAgent agent;
    public SpriteRenderer troopSprite;
    public PlayerSM target;
    public bool isHighlighted = false;
    public static bool mouseOverTroop = false;
    public Collider2D[] hitColliders;
    public EnemySMBase enemy;

    public float attackRange;
    
    public TroopChargeEnemy troopCharge {get; protected set;}
    public TroopFollowState troopFollow {get; protected set;}
    public TroopGoToSpotState troopGoTo {get; protected set;}
    public TroopDefendingState troopDefending {get; protected set;}

    public TroopSMBase()
    {

    }

    protected override void Init()
    {
        troopSprite = GetComponent<SpriteRenderer>();
        this.agent = this.GetComponent<NavMeshAgent>();
        this.agent.updateRotation = false;
        this.agent.updateUpAxis = false;
    }

    void OnMouseDown()
    {   
        //Debug.Log("MouseDown " + !mouseOverTroop);
        mouseOverTroop = true;
    }

    void OnMouseUp()
    {
        //Debug.Log("MouseUp " + !mouseOverTroop);
        mouseOverTroop = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTrigger enter" + !isHighlighted);
        if (collision.gameObject.GetComponent<BoxSelection>())
        {
            troopSprite.color = new Color(1f, 0f, 0f, 1f);
            isHighlighted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("OnTrigger exit" + !isHighlighted);
        if (collision.gameObject.GetComponent<BoxSelection>() && Input.GetMouseButton(0))
        {
            troopSprite.color = new Color(1f, 1f, 1f, 1f);
            isHighlighted = false;
        }
    }

}
