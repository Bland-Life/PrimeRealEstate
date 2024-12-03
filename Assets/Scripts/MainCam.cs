using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] float screenHeight;
    public float pixelsPerUnit = 32f; // Your PPU

    void Start()
    {
        UpdateCameraSize();
    }

    void UpdateCameraSize()
    {
        // Calculate the orthographic size based on the screen's aspect ratio
        float screenHeight = Screen.height;
        float orthographicSize = (screenHeight / 2) / pixelsPerUnit;
        mainCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
