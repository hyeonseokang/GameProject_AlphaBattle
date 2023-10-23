using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {

    public GameObject weapon_btn;
    public GameObject weapon_bg;

    public GameObject adjective_btn;
    public GameObject adjective_bg;

    public GameObject skill_btn;
    public GameObject skill_bg;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void skill_on()
    {
        skill_btn.SetActive(false);
        weapon_btn.SetActive(true);
        adjective_btn.SetActive(true);

        skill_bg.SetActive(true);
        weapon_bg.SetActive(false);
        adjective_bg.SetActive(false);
    }

    public void weapon_on()
    {
        skill_btn.SetActive(true);
        weapon_btn.SetActive(false);
        adjective_btn.SetActive(true);

        skill_bg.SetActive(false);
        weapon_bg.SetActive(true);
        adjective_bg.SetActive(false);
    }

    public void adjective_on()
    {
        skill_btn.SetActive(true);
        weapon_btn.SetActive(true);
        adjective_btn.SetActive(false);

        skill_bg.SetActive(false);
        weapon_bg.SetActive(false);
        adjective_bg.SetActive(true);
    }

    public void MatchingStart()
    {

    }
}