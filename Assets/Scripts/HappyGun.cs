using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HappyGun : MonoBehaviour {

    public GameObject projectile;

    public Level level;
    SteamVR_TrackedObject trackedObj;

    public AudioSource blastSound;

    void Awake()
    {
        trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate () {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        Debug.DrawLine(transform.position, transform.position - transform.up);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && level.GameStarted)
        {
            GameObject projObject = (GameObject)Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            projObject.transform.Rotate(0, transform.rotation.y, 0);
            Vector3 point = (transform.position - transform.up);
            Vector3 dir = (point - projObject.transform.position).normalized;
            projObject.GetComponent<Rigidbody>().AddForce(dir * 20, ForceMode.Impulse);
            blastSound.Play();
        }
	}
}
