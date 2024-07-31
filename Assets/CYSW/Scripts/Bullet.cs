﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float BulletSpd = 0f;
    public float BulletDist = 0f;

	// Use this for initialization
	void Start () {
        //Destroy(this.gameObject, BulletDist);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * BulletSpd * Time.deltaTime);
	}
}
