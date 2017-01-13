using UnityEngine;
using System.Collections;

public class Dinosaur : MonoBehaviour {

    private bool happy = false;
    public AudioClip[] dinoSounds;

    public bool Happy
    {
        get
        {
            return happy;
        }
    }

	void SetHappy () {
        happy = true;
	}

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.gameObject.tag == "Bullet")
        {
            collider.collider.gameObject.SendMessage("explode");
            SetHappy();
            GameObject.Find("LevelManager").SendMessage("updateDinoHappy");
            float soundPitch = Random.Range(0.8f, 3.0f);
            int soundClip = Mathf.RoundToInt(Random.Range(0, dinoSounds.Length - 1));
            gameObject.GetComponent<AudioSource>().pitch = soundPitch;
            gameObject.GetComponent<AudioSource>().clip = dinoSounds[soundClip];
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
