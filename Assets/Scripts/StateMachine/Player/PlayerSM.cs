using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerSM : StateMachine
{
    [field:SerializeField] public InputActionAsset playerActions{get; private set;}
    [field:SerializeField] public Rigidbody2D myRigidBody{get; private set;}
    [SerializeField] public int moveSpeed = 5;
    [field:SerializeField] public Canvas buildCanvas{get; private set;}
    [field:SerializeField] public CinemachineVirtualCamera mainCamera{get; private set;}
    [field:SerializeField] public GameObject cameraTarget{get; private set;}
    [field:SerializeField] public GameObject tileHighlighter{get; private set;}
    [field:SerializeField] public BuildGrid buildGrid{get; private set;}
    public Buildable buildObj = null;

    public PlayerIdleState idleState {get; private set;}
    public PlayerWalkState walkState {get; private set;}
    public PlayerBuildingState buildingState {get; private set;}
    public PlayerSM() {
        idleState = new PlayerIdleState(this);
        walkState = new PlayerWalkState(this);
        buildingState = new PlayerBuildingState(this);
        currentState = idleState;
    }

    protected override void Init()
    {
        buildGrid = FindObjectOfType<BuildGrid>();
    }
}
