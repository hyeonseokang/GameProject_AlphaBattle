using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public float Delay = 0f;

	// Use this for initialization
	void Start () {
        transform.name = "Blade";
        Destroy(gameObject, Delay);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void ColliderOut()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
