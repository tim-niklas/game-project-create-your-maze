using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    //Slider
    public Slider heightSlider;
    public Slider widthSlider;

    // Slider texts
    public TMP_Text heightText;
    public TMP_Text widthText;

    // Maze values
    public float heightValue;
    public float widthValue;

    // Camera
    public Camera mainCamera;

    // Gameplay
    public GameObject player;
    public GameObject goal;

    // Maze creator
    GameObject prevCreator;
    public GameObject mazeCreatorPrefab;

    // Update is called once per frame
    void Update()
    {
        // Get the size of maze from sliders
        heightValue = heightSlider.value;
        widthValue = widthSlider.value;

        // Change slider texts
        heightText.text = heightValue.ToString();
        widthText.text = widthValue.ToString();
    }

    // If the "Create" button is pressed
    public void createButtonPressed()
    {
        // Hide UI
        this.gameObject.SetActive(false); 

        // Activate player and set position of player
        player.SetActive(true);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = new Vector3(0, 0, 0);
        player.GetComponent<CharacterController>().enabled = true;

        // Set goal
        goal.SetActive(true);
        goal.transform.position = new Vector3(widthValue * 2 - 2, 0, heightValue * 2 - 2);

        // Change Camera view
        mainCamera.GetComponent<CameraController>().changeCameraView();

        // Delete previous Creator and instantiate new Creator + create Maze
        prevCreator = GameObject.FindWithTag("MazeCreator");
        Destroy(prevCreator);
        GameObject mazeCreator = Instantiate(mazeCreatorPrefab);
        mazeCreator.GetComponent<MazeController>().createMaze((int)widthValue, (int)heightValue);
    }
}
