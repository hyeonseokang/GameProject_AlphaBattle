using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBtn : MonoBehaviour
{



    int[] Alpha = new int[26];
    int count = 0;


    public GameObject ButtonObj;
    public GameObject BtnParent;
    public InputField BenchText;

    public GameObject WordParent;

    public Image[] ButtonArray;
    
    string bench;

    // Use this for initialization
    void Start()
    {

        Alpha = InventoryMng.instance.Alpha;

        
        for (int i = 0; i < Alpha.Length; i++)
        {
            for (int j = 0; j < Alpha[i]; j++)
            {
                string tempstr = string.Empty;
                tempstr += (char)(97 + i);
                int u = count;
                GameObject Temp = Instantiate(ButtonObj);
                Temp.transform.SetParent(BtnParent.transform);
                Temp.GetComponentInChildren<Text>().text = tempstr;

                Temp.GetComponent<Button>().onClick.AddListener(() => SelectBtn(tempstr));
                Temp.GetComponent<Button>().onClick.AddListener(() => DestroyBtn(u));
                

                count++;
            }

        }
        ButtonArray = new Image[count];
        ButtonArray = BtnParent.GetComponentsInChildren<Image>();

    }



    public void SelectBtn(string c)
    {
        Debug.Log(c);
        bench += c;
        BenchText.text = bench;
        Debug.Log(bench);
    }

    public void DestroyBtn(int _num)
    {
        Debug.Log(_num);
        Destroy(ButtonArray[_num].gameObject);
    }

    public void Makeword()
    {
        switch (bench)
        {
            case "strong":
                CreateWord(bench,(int)Adjective.STRONG,"Adjective");
                break;
        }
    }

    void CreateWord(string s , int num , string aa)
    {
        string path = "SMH/Prefabs/" + aa.ToString() + "/" + s +  "Word";
        Debug.Log(path);
        GameObject prefab = Resources.Load(path) as GameObject;
        GameObject TempGame = Instantiate(prefab) as GameObject;

        TempGame.transform.parent = WordParent.transform;


     
    }

    //public void ValueChange(string s)
    //{

    //    Debug.Log(s[s.Length-1]);

    //    char ch = s[s.Length - 1];


    //    for (int i = 0; i < Alpha.Length; i++)
    //    {
    //        if (ch == (char)(97 + i))
    //        {
    //            if (Alpha[i] > 0)
    //            {
    //                Alpha[i]--;
    //                Debug.Log("aa");
    //                break;
    //            }
    //            else
    //            {
    //                Debug.Log("bb");
    //                s = s.Substring(s.Length - 1);
    //                BenchText.text = s;
    //                break;
    //            }
    //        }
    //    }
    //}

}
