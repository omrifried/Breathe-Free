﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class EndgameButtonsFruit : MonoBehaviour
{
    private GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void buttonPress()
    {
        game = EventSystem.current.currentSelectedGameObject;
        if (game.name == "RetryButton")
        {
            SceneManager.LoadScene("FruitWorld");
        }
        else
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
