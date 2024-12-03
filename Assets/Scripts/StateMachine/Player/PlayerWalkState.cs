using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : IState
{
    PlayerSM playerSM;
    private InputActionMap movementMap;
    public AudioSource myAudio;
    public PlayerWalkState(PlayerSM mySM) {
        playerSM = mySM;
    }

    public void Start()
    {
        movementMap = playerSM.playerActions.FindActionMap("Movement");
        playerSM.playerActions.Enable();
        myAudio = playerSM.GetComponent<AudioSource>();
        myAudio.Play();
    }

    public void Update()
    {
        if (movementMap.FindAction("Walk").ReadValue<Vector2>().Equals(Vector2.zero)) {
            playerSM.TransitionState(playerSM.idleState);
        }
        else if (movementMap.FindAction("SwitchToBuilding").IsPressed()) {
            playerSM.TransitionState(playerSM.buildingState);
        }
        else {
            Walk();
        }
    }

    public void Exit()
    {
        playerSM.myRigidBody.velocity = Vector2.zero;
        myAudio.Stop();
        playerSM.playerActions.Disable();
    }

    private void Walk() {
        playerSM.myRigidBody.velocity = movementMap.FindAction("Walk").ReadValue<Vector2>() * playerSM.moveSpeed;
    }
}
