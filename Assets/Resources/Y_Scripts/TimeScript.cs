using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {
    private float LimitTime;
    private bool TimeCheck;
    public Text TimeText;
    Animation ani;
	// Use this for initialization
	void Start () {
        TimeCheck = true;
        LimitTime = 60f;
        TimeText.text = LimitTime.ToString("N0");
    }
    public Image ajaj;
	// Update is called once per frame
	void Update () {
        if (TimeCheck)
        {
            if(LimitTime <= 0)
            {
                TimeCheck = !TimeCheck;
            }
            LimitTime -= Time.deltaTime;
            TimeText.text = LimitTime.ToString("N0");
        }
        else
        {
            LimitTime = 0;
            TimeText.text = LimitTime.ToString("N0");
            ajaj.GetComponent<Animator>().SetTrigger("rkrk");
            Invoke("Ffien", 1.0f);
        }
        
	}
    public void Ffien()
    {
        SceneManager.LoadScene("RealMixScene");
    }
}
