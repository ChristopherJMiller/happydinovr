using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public GameObject explosion;

	void explode () {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
	}
}
