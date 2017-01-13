using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class LevelSelector : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    public float selectDistance = 0.5f;

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("LevelSelect"))
            {
                Debug.Log(Vector3.Distance(gameObject.transform.position, obj.transform.position));
                if (Vector3.Distance(gameObject.transform.position, obj.transform.position) < selectDistance)
                {
                    SteamVR_Fade.View(Color.white, 1);
                    SceneManager.LoadScene(obj.name);
                }
            }
        }
    }
}
