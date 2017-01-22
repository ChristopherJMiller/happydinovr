using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve;

public class Load : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}