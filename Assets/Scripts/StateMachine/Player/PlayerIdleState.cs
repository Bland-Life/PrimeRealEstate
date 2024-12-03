using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerIdleState : IState
{
    PlayerSM playerSM;
    private InputActionMap movementMap;
    private CinemachineConfiner2D confiner2D;
    public PlayerIdleState(PlayerSM mySM) {
        playerSM = mySM;
    }

    void IState.Start()
    {
        movementMap = playerSM.playerActions.FindActionMap("Movement");
        playerSM.playerActions.Enable();
        if (SceneManager.GetActiveScene().name == "Town") {
            confiner2D = playerSM.mainCamera.GetComponent<CinemachineConfiner2D>();
            if (confiner2D.m_BoundingShape2D == null) {
                confiner2D.m_BoundingShape2D = GameObject.FindObjectOfType<PolygonCollider2D>();
            }
            confiner2D.InvalidateCache();
        }
    }

    void IState.Update()
    {
        if (!movementMap.FindAction("Walk").ReadValue<Vector2>().Equals(Vector2.zero)) {
            playerSM.TransitionState(playerSM.walkState);
        }
        else if (movementMap.FindAction("SwitchToBuilding").IsPressed()) {
            playerSM.TransitionState(playerSM.buildingState);
        }
    }

    void IState.Exit() {
        playerSM.playerActions.Disable();
    }
}
