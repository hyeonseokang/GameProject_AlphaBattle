using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iosevnsoei : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        Vector3 target = Camera.main.ScreenToWorldPoint(pos);

        float digree = Mathf.Atan2(target.y - transform.position.y,
            target.x - transform.position.x) * 180f / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, digree);
    }
}
