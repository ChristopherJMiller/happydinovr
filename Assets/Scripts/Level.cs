using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public string gameTitle;
    public Dinosaur[] dinosaurs;


    private bool gameStarted = true;

    private int dinosUnhappy;
    private bool shouldCheckDinos = false;
    private bool complete = false;
    private float timeInLevel = 0;

	// Use this for initialization
	void Start () {
        dinosUnhappy = dinosaurs.Length;
        Random.InitState(Mathf.RoundToInt(Time.time * 100000));
        SteamVR_Fade.View(Color.clear, 1);
	}

    public bool GameStarted
    {
        get
        {
            return gameStarted;
        }
    }

    public bool LevelCompleted
    {
        get
        {
            return complete;
        }
    }

    public int UnhappyDinos
    {
        get
        {
            return dinosUnhappy;
        }
    }

    public int NumOfDinos
    {
        get
        {
            return dinosaurs.Length;
        }
    }

    public float LevelTime
    {
        get
        {
            return timeInLevel;
        }
    }

    public void startGame()
    {
        gameStarted = true;
    }

    void checkCompletion()
    {
        if (dinosUnhappy <= 0)
        {
            complete = true;
        }
    }

    void FixedUpdate ()
    {
        if (gameStarted)
        {
            timeInLevel += Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update () {
	    if (shouldCheckDinos)
        {
            int happyCount = 0;
            foreach(Dinosaur dino in dinosaurs)
            {
                if (dino.Happy)
                {
                    happyCount++;
                }
            }
            dinosUnhappy = dinosaurs.Length - happyCount;
            shouldCheckDinos = false;
            checkCompletion();
        }
	}

    void updateDinoHappy ()
    {
        shouldCheckDinos = true;
    }
}
