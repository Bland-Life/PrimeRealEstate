using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SummonTeleportMenu : MonoBehaviour
{
    public GameObject TeleportMenuIndicator;
    public GameObject TeleportMenu;
    public bool isCollided = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollided = true;
        TeleportMenuIndicator.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(TeleportMenuIndicator != null)
            TeleportMenuIndicator.SetActive(false);
        isCollided = false;
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        TeleportMenu.SetActive(false);
    }

    void Update()
    {   
        if(isCollided)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                TeleportMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }    
    }

    void Start()
    {
        TeleportMenu.SetActive(false);
        TeleportMenuIndicator.SetActive(false);
    }
}
