using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ReadyLevel : MonoBehaviour {

    public Level level;

    public int timeUntilBegin = 3;
    private float currentHolddown = 0;
    private bool countdown = false;

    public GameObject getReadyTextObj;
    public Text countdownUI;

    public AudioClip countdownDing;

    private AudioSource source;
    int currentSecond;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
        GetComponent<VRTK_ControllerEvents>().GripReleased += new ControllerInteractionEventHandler(DoGripReleased);
        currentSecond = timeUntilBegin;
    }

    private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        countdown = true;
    }

    private void DoGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        countdown = false;
    }

    private void Update()
    {
        if (countdown)
        {
            countdownUI.gameObject.SetActive(true);
            getReadyTextObj.SetActive(true);
            currentHolddown += Time.deltaTime;
            TimeSpan elapsed = TimeSpan.FromSeconds(timeUntilBegin - currentHolddown);
            if (currentSecond != elapsed.Seconds)
            {
                source.PlayOneShot(countdownDing);
                currentSecond = elapsed.Seconds;
            }
            countdownUI.text = elapsed.Seconds.ToString().PadLeft(2, '0') + ":" + elapsed.Milliseconds.ToString().PadLeft(3, '0');
            if (currentHolddown >= timeUntilBegin)
            {
                level.startGame();
                countdownUI.gameObject.SetActive(false);
                getReadyTextObj.SetActive(false);
                this.enabled = false;
            }
        } else
        {
            countdownUI.gameObject.SetActive(false);
            getReadyTextObj.SetActive(false);
             currentHolddown = 0;
        }
    }
}
