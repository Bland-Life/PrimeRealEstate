using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class TileHighlighter : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject tileHighlighter;

    void Start() {
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        Vector2 mouse_pos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 highlightPos = new Vector2(Mathf.Floor(mouse_pos.x) + 0.5f, Mathf.Floor(mouse_pos.y) + 0.5f);
        tileHighlighter.transform.position = highlightPos;
    }
}
