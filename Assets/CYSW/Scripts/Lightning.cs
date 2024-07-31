using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Remove()
    {
        Destroy(gameObject);
    }

    public void Rieifeif()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void awdawdRieifeif()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
