using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour {

    private int currentSelected = 0;

    public List<LevelModel> levels = new List<LevelModel>();

    public Text playButtonText;

    public void IncrementSelect()
    {
        currentSelected++;
        if (currentSelected > levels.Count)
        {
            currentSelected = 0;
        }
        UpdateSelected();
    }

    public void DecrementSelect()
    {
        currentSelected--;
        if (currentSelected < 0)
        {
            currentSelected = levels.Count;
        }
        UpdateSelected();
    }

    public void UpdateSelected()
    {
        playButtonText.text = levels[currentSelected].levelName;
        Camera.main.transform.LookAt(levels[currentSelected].model.transform);
    }

    public void PlaySelected()
    {
        SceneManager.LoadScene(levels[currentSelected].sceneName, LoadSceneMode.Single);
    }

    public void Start()
    {
        UpdateSelected();
    }
}
