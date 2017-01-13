using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    public GameObject target;
    public float rotationSpeed;

	void Update () {
        transform.LookAt(target.transform);
        transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * rotationSpeed);
	}
}
