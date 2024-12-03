using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBuildingState : IState
{
    PlayerSM playerSM;
    private InputActionMap buildMap;
    private GameObject tileHighlighter;
    
    private JSONLoader town;
    private CinemachineConfiner2D confiner2D;

    private ResourcesUI resources;

    // The center of a tile is usually the tiles coordinates plus 0.5f,
    // so the center of our tile at coordinates (0, 0) is (0.5, 0.5).
    // This is useful for when we're placing buildings in a tile and want it centered.
    private Vector2 centerTileOffset = new Vector2(0.5f, 0.5f);

    private bool in_town = true; 

    public PlayerBuildingState(PlayerSM mySM) {
        playerSM = mySM;
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().name != "Town") {
            in_town = false;
            playerSM.TransitionState(playerSM.idleState);
            return;
        }

        town = GameObject.FindObjectOfType<JSONLoader>();
        town.LoadData();
        resources = GameObject.FindObjectOfType<ResourcesUI>();
        playerSM.buildCanvas.gameObject.SetActive(true);
        tileHighlighter = Object.Instantiate(playerSM.tileHighlighter);
        buildMap = playerSM.playerActions.FindActionMap("Building");
        playerSM.playerActions.Enable();
        playerSM.mainCamera.m_Lens.OrthographicSize *= 2;
        confiner2D = playerSM.mainCamera.GetComponent<CinemachineConfiner2D>();
        confiner2D.InvalidateCache();
    }

    public void Update()
    {
        
        if (buildMap.FindAction("Place").IsPressed()) {
            PlaceBuilding();
        }

        if (buildMap.FindAction("Remove").IsPressed()) {
            RemoveBuilding();
        }

        Move();

        if (buildMap.FindAction("SwitchToIdle").IsPressed()) {
            playerSM.TransitionState(playerSM.idleState);
        }

    }
    public void Exit()
    {
        if (!in_town) return;

        playerSM.playerActions.Disable();
        playerSM.buildCanvas.gameObject.SetActive(false);
        Object.Destroy(tileHighlighter);
        playerSM.mainCamera.m_Lens.OrthographicSize /= 2;
        confiner2D.InvalidateCache();
        playerSM.cameraTarget.transform.localPosition = Vector3.zero;
    }

    private void Move() {
        // Bounds the cameraTarget to the center of the camera such that when it hits the boundary, the camera object
        // won't move beyond the playable area.
        playerSM.cameraTarget.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

        // Moves the cameraTarget
        playerSM.cameraTarget.transform.localPosition += (Vector3)buildMap.FindAction("Move").ReadValue<Vector2>() * playerSM.moveSpeed * Time.deltaTime;
    }

    private void PlaceBuilding() {

        if (playerSM.buildObj == null) {
            return;
        }
        // Getting the current mouse coordinates relative to the World point.
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
        // Rounding the coordinates to whole numbers.
        mouse_pos = new Vector2(Mathf.Floor(mouse_pos.x), Mathf.Floor(mouse_pos.y)); 
        // Find all objects on a tile.
        Collider2D[] colliders = Physics2D.OverlapBoxAll(mouse_pos + centerTileOffset, new Vector2(0.95f, 0.95f), 0);
        // If there are no obstacles on a tile, place our building there.
        bool obstacles = EventSystem.current.IsPointerOverGameObject();
        bool materials = (town.inventory.wood >= playerSM.buildObj.cost);
        if (!obstacles && colliders.Length == 0 && materials) {
            if (playerSM.buildObj.obj != null) {
                playerSM.buildObj.place(playerSM.buildGrid.transform, mouse_pos);
            }
            else if (playerSM.buildObj.tile != null) {
                playerSM.buildObj.place(mouse_pos);
            }
            resources.removeWood(playerSM.buildObj.cost);
            
        }
        else {
            Debug.Log(colliders);
        }
    }

    private void RemoveBuilding() {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouse_pos = new Vector2(Mathf.Floor(mouse_pos.x), Mathf.Floor(mouse_pos.y)); 
        Collider2D[] colliders = Physics2D.OverlapBoxAll(mouse_pos + centerTileOffset, new Vector2(0.95f, 0.95f), 0);
        if (!EventSystem.current.IsPointerOverGameObject() && colliders.Length > 0) {
            Debug.Log(colliders.Length);
            foreach(Collider2D collider in colliders) {
                GameObject colliderObj = collider.gameObject;
                if (colliderObj.tag == "Buildable") {
                    resources.addWood(colliderObj.transform.parent.gameObject.GetComponent<BuildOBJ>().cost);
                    Object.Destroy(colliderObj.transform.parent.gameObject);
                }
            }
        }
        
    }
}
