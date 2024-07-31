using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour {

    public GameObject UI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManger.instance.Play(AudioEnum.CLICK);
            gameObject.SetActive(false);
            UI.SetActive(true);
        }
	}
}
