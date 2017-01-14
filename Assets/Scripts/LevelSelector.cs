using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class LevelSelector : VRTK_InteractableObject
{

    public string levelToLoad;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        SceneManager.LoadScene(levelToLoad);
    }
}
