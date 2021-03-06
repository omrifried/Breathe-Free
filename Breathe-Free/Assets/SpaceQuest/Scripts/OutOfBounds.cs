﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBounds : MonoBehaviour
{
    public GameObject player;
    public RocketController playerScript;
    public GameObject mainCam;

    public GameObject arrowOne;
    public GameObject arrowTwo;
    public GameObject arrowThree;
    public GameObject arrowFour;

    public float timer = 2.5f;

    private GameObject OutOfBoundsCanvas;
    private Text outOfBoundsText;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        // Find objects.
        player = GameObject.FindGameObjectWithTag("Rocket");
        playerScript = player.GetComponent<RocketController>();
        outOfBoundsText = GameObject.FindGameObjectWithTag("Out Of Bounds").GetComponent<Text>();
        OutOfBoundsCanvas = GameObject.FindGameObjectWithTag("Out Of Bounds Canvas");

        // Set all arrows to invisible.
        arrowOne.GetComponent<Renderer>().enabled = false;
        arrowTwo.GetComponent<Renderer>().enabled = false;
        arrowThree.GetComponent<Renderer>().enabled = false;
        arrowFour.GetComponent<Renderer>().enabled = false;
    }

    /**
     * Update is called once per frame.
     */
    void Update()
    {
        // If the game isn't over, create dyanmic out of bounds image on screen.
        if (!playerScript.gameOver)
        {
            // Only print error when the camera view is out of bounds.
            if ((mainCam.transform.rotation.eulerAngles.y >= 0 && mainCam.transform.rotation.eulerAngles.y <= 60) || (mainCam.transform.rotation.eulerAngles.y >= 300 && mainCam.transform.rotation.eulerAngles.y <= 360))
            {
                // Lock Rotation on X and Z Axis.
                OutOfBoundsCanvas.transform.rotation = Quaternion.Euler(0, mainCam.transform.rotation.eulerAngles.y, 0);
				outOfBoundsText.text = "";

				// Turn off arrows.
				arrowOne.GetComponent<Renderer>().enabled = false;
                arrowTwo.GetComponent<Renderer>().enabled = false;
                arrowThree.GetComponent<Renderer>().enabled = false;
                arrowFour.GetComponent<Renderer>().enabled = false;
            }
            else
            {
				// Lock Rotation on X and Z Axis.
				OutOfBoundsCanvas.transform.rotation = Quaternion.Euler(0, mainCam.transform.rotation.eulerAngles.y, 0);
                outOfBoundsText.text = "RETURN TO SHIP";
                timer -= Time.deltaTime;

                // If the player is looking left, put the right arrows on.
                if (Camera.main.transform.rotation.eulerAngles.y < 300 && mainCam.transform.rotation.eulerAngles.y >= 180)
                {
                    LookLeft();
                }

                // If the player is looking right, put the left arrows on.
                else 
                {
                    LookRight();
                }
            }
        }
        // Otherwise, remove the out of bounds indicator and allow the player to free roam.
        else
        {
            // Lock Rotation on X and Z Axis.
            OutOfBoundsCanvas.transform.rotation = Quaternion.Euler(0, mainCam.transform.rotation.eulerAngles.y, 0);
            outOfBoundsText.text = "";
			OutOfBoundsCanvas.SetActive(false);
			arrowOne.GetComponent<Renderer>().enabled = false;
            arrowTwo.GetComponent<Renderer>().enabled = false;
            arrowThree.GetComponent<Renderer>().enabled = false;
            arrowFour.GetComponent<Renderer>().enabled = false;
        }
    }

    /**
     * If the player is looking right beyond the camera bounds, display arrows to guide
     * the player back to the ship. The arrows will stagger to create a blinking effect and direct
     * the player to the correct direction. The arrows stagger based on a timer.
     */
    private void LookRight()
	{
        // Stagger arrow visbility
        if (timer >= 2f)
        {
            arrowOne.GetComponent<Renderer>().enabled = false;
            arrowTwo.GetComponent<Renderer>().enabled = false;
            arrowThree.GetComponent<Renderer>().enabled = false;
            arrowFour.GetComponent<Renderer>().enabled = false;
        }
        else if (timer < 2f && timer >= 1f)
        {
            arrowOne.GetComponent<Renderer>().enabled = false;
            arrowTwo.GetComponent<Renderer>().enabled = false;
            arrowThree.GetComponent<Renderer>().enabled = true;
            arrowFour.GetComponent<Renderer>().enabled = false;
        }
        else if (timer < 1f && timer >= 0)
        {
            arrowOne.GetComponent<Renderer>().enabled = false;
            arrowTwo.GetComponent<Renderer>().enabled = false;
            arrowThree.GetComponent<Renderer>().enabled = false;
            arrowFour.GetComponent<Renderer>().enabled = true;
        }
        // Reset timer.
        else
        {
            timer = 2.5f;
        }
    }

    /**
     * If the player is looking left beyond the camera bounds, display arrows to guide
     * the player back to the ship. The arrows will stagger to create a blinking effect and direct
     * the player to the correct direction. The arrows stagger based on a timer.
     */
    private void LookLeft()
	{
        // Stagger arrow visbility
        if (timer >= 2f)
        {
            arrowOne.GetComponent<Renderer>().enabled = false;
            arrowTwo.GetComponent<Renderer>().enabled = false;
            arrowThree.GetComponent<Renderer>().enabled = false;
            arrowFour.GetComponent<Renderer>().enabled = false;
        }
        else if (timer < 2f && timer >= 1f)
        {
            arrowOne.GetComponent<Renderer>().enabled = true;
            arrowTwo.GetComponent<Renderer>().enabled = false;
            arrowThree.GetComponent<Renderer>().enabled = false;
            arrowFour.GetComponent<Renderer>().enabled = false;
        }
        else if (timer < 1f && timer >= 0)
        {
            arrowOne.GetComponent<Renderer>().enabled = false;
            arrowTwo.GetComponent<Renderer>().enabled = true;
            arrowThree.GetComponent<Renderer>().enabled = false;
            arrowFour.GetComponent<Renderer>().enabled = false;
        }
        // Reset timer.
        else
        {
            timer = 2.5f;
        }
    }
}
