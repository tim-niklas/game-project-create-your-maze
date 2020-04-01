using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject winCanvas;
    public GameObject thirdPersonCamera;

    // Update is called once per frame
    void Update()
    {
        // Show UI
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (menuCanvas.activeSelf)
            {
                menuCanvas.SetActive(false);
            }
            else if (menuCanvas.activeSelf == false)
            {
                menuCanvas.SetActive(true);
                winCanvas.SetActive(false);
            }
        }

        // Change camera (2D - 3D)
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (thirdPersonCamera.activeSelf)
            {
                thirdPersonCamera.SetActive(false);
            }
            else if (thirdPersonCamera.activeSelf == false)
            {
                thirdPersonCamera.SetActive(true);
            }
        }

    }
}
