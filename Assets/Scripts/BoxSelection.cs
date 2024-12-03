using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelection : MonoBehaviour
{
    private LineRenderer lineRend;
    private Vector2 initialMousePosition, currentMousePosition;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !TroopSMBase.mouseOverTroop)
        {
            lineRend.positionCount = 4;
            initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(1, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(2, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(3, new Vector2(initialMousePosition.x, initialMousePosition.y));
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
            boxCollider.offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        if(Input.GetMouseButton(0) && !TroopSMBase.mouseOverTroop)
        {
            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(1, new Vector2(initialMousePosition.x, currentMousePosition.y));
            lineRend.SetPosition(2, new Vector2(currentMousePosition.x, currentMousePosition.y));
            lineRend.SetPosition(3, new Vector2(currentMousePosition.x, initialMousePosition.y));

            transform.position = (currentMousePosition + initialMousePosition) / 2;
            boxCollider.size = new Vector2(Mathf.Abs(initialMousePosition.x - currentMousePosition.x), Mathf.Abs(initialMousePosition.y - currentMousePosition.y));
        }

        if(Input.GetMouseButtonUp(0))
        {
            lineRend.positionCount = 0;
            Destroy(boxCollider);
            transform.position = Vector3.zero;
        }
    }
}
