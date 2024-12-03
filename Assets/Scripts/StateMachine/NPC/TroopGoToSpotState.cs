using UnityEngine;
using UnityEngine.InputSystem;

public class TroopGoToSpotState : IState
{
    TroopSMBase troopSM;
    Vector2 mouse_pos;

    public TroopGoToSpotState(TroopSMBase mySM)
    {
        troopSM = mySM;
    }

    public void Exit()
    {
        
    }

    public void Start()
    {
        mouse_pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
        mouse_pos = new Vector2(Mathf.Floor(mouse_pos.x), Mathf.Floor(mouse_pos.y));
        troopSM.isHighlighted = false;
        troopSM.troopSprite.color = new Color(1f, 1f, 1f, 1f);
    }

    public void Update()
    {
        troopSM.agent.SetDestination(mouse_pos);
        if(troopSM.isHighlighted && Input.GetMouseButtonDown(0))
        {
            troopSM.TransitionState(troopSM.troopGoTo);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            troopSM.TransitionState(troopSM.troopFollow);
        }
        if(troopSM.agent.remainingDistance < 0.5)
        {
            troopSM.TransitionState(troopSM.troopDefending);
        }
    }
}
