using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    // Get the size of the generated maze
    public Slider heightSlider;
    public Slider widthSlider;

    public void changeCameraView()
    {
        // Enable the camera (the one that is orthographic)
        Camera.main.enabled = true;

        // Change the size of camera for horizontal and vertical fit
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = widthSlider.value / heightSlider.value;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = heightSlider.value;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = heightSlider.value * differenceInSize;
        }

        // Change the camera position so that the maze is in the mid
        transform.position = new Vector3(widthSlider.value - 1, 100, heightSlider.value - 1);
    }
}