using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Globalization;

public class UIController : MonoBehaviour {

    public GameObject inGame;

    public Text dinoLeft;
    public Text levelTitle;
    public Text timer;
    private Level level;
 

    void Start()
    {
        level = gameObject.GetComponent<Level>();
    }
    

	void Update () {
        if (!level.GameStarted && !level.LevelCompleted)
        {
            timer.gameObject.SetActive(false);
        } else
        {
            timer.gameObject.SetActive(true);
        }
        levelTitle.text = level.gameTitle;
        dinoLeft.text = "Unhappy Dinosaurs: " + level.UnhappyDinos;
        if (!level.LevelCompleted)
        {
            TimeSpan elapsed = TimeSpan.FromSeconds(level.LevelTime);
            timer.text = elapsed.Minutes.ToString().PadLeft(2, '0') + ":" + elapsed.Seconds.ToString().PadLeft(2, '0') + ":" + elapsed.Milliseconds.ToString().PadLeft(3, '0');
        }
    }
}
