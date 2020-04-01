using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public GameObject winCanvas;

    // Update is called once per frame
    void Update()
    {
        // Key Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.Normalize(transform.right * x + transform.forward * z);
        controller.Move(move * speed * Time.deltaTime);
    }

    // If player reach goal
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            winCanvas.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

