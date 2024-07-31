using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{

    SpriteRenderer spr;

    public Sprite[] S;

    // Use this for initialization
    void Start()
    {

        Debug.Log(S[0].name);

        spr = transform.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        int wea = InventoryMng.instance.UseWea;
        int adj = InventoryMng.instance.UseAdj;
        string WeaponName;
        if (adj > 0)
        {
            WeaponName = ((Adjective)adj).ToString() + "_" + ((Weapon)wea).ToString();

            WeaponName = WeaponName.ToLower();
            Debug.Log(WeaponName);
            Debug.Log(S[10].name);
        }
        else
        {
            WeaponName = ((Weapon)wea).ToString();
            WeaponName = WeaponName.ToLower();
            Debug.Log(WeaponName);
            Debug.Log(S[11].name);
        }
        for (int i = 0; i < S.Length; i++)
        {
            if (WeaponName == S[i].name)
            {
                spr.sprite = S[i];
                Debug.Log("aa");
            }
        }

    }
}


//------------------------------------------------------------------------
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ChangeWeapon : MonoBehaviour
//{
//    public GameObject[] S;

//    // Use this for initialization
//    void Start()
//    {
//        //int wea = InventoryMng.instance.UseWea;
//        //int adj = InventoryMng.instance.UseAdj;
//        //string WeaponName;
//        //if (adj > 0)
//        //{

//        //    WeaponName = ((Adjective)adj).ToString() + "_" + ((Weapon)wea).ToString();

//        //    WeaponName = WeaponName.ToLower();
//        //    Debug.Log(WeaponName);
//        //}
//        //else
//        //{
//        //    WeaponName = ((Weapon)wea).ToString();
//        //    WeaponName = WeaponName.ToLower();

//        //    Debug.Log(WeaponName);
//        //}
//        //for (int i = 0; i < S.Length; i++)
//        //{
//        //    if (WeaponName == S[i].name)
//        //    {
//        //        Instantiate(S[i], transform);
//        //    }
//        //}
//    }

//    public void ChangeWea()
//    {
//        int wea = InventoryMng.instance.UseWea;
//        int adj = InventoryMng.instance.UseAdj;
//        string WeaponName;
//        if (adj > 0)
//        {

//            WeaponName = ((Adjective)adj).ToString() + "_" + ((Weapon)wea).ToString() + " 1";

//            WeaponName = WeaponName.ToLower();
//            Debug.Log(WeaponName);
//        }
//        else
//        {
//            WeaponName = ((Weapon)wea).ToString() + " 1";
//            WeaponName = WeaponName.ToLower();

//            Debug.Log(WeaponName);
//        }
//        for (int i = 0; i < S.Length; i++)
//        {
//            if (WeaponName == S[i].name)
//            {
//                Transform[] childList = GetComponentsInChildren<Transform>(true);
//                if (childList != null)
//                {
//                    for (int j = 0; j < childList.Length; j++)
//                    {
//                        if (childList[j] != transform)
//                            Destroy(childList[j].gameObject);
//                    }
//                }

//                GameObject Temp = Instantiate(S[i], transform);
//                Temp.layer = 5;
//            }
//        }
//    }

//}

