using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class asdf : MonoBehaviour {

    public Text text2123;
    public Text exp;
    char[] str = new char[255];
    int[] cnt = new int[26];


    // Use this for initialization
    void Start () {
        
        
        		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("RealMixScene");
        }


    }

    public void asdfdd()
    {


        char[] str = new char[9999999];
        int[] cnt = new int[26];

        exp.text = string.Empty;

        for (int i = 0; i < text2123.text.Length; i++)
        {
            str[i] = text2123.text[i];
            if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                if (str[i] <= 'Z')
                {
                    Debug.Log("bb");
                    cnt[str[i] - 'A']++;
                }
                else
                {
                    Debug.Log("cc");
                    cnt[str[i] - 'a']++;
                }
        }

        for (int i = 0; i < 26; i++)
                exp.text = exp.text + (char)('A' + i) + cnt[i].ToString() + '개' + ' ';

        Debug.Log(exp.text + (char)('A' + 1) + cnt[1].ToString());

        Debug.Log("ㄴㄴㄴ");
    }

}
