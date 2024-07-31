using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameChangeWeapon : MonoBehaviour
{
    public GameObject[] S;
    GameObject WeaponObject;
    void Start()
    {
        if (GetComponent<PhotonView>().isMine)
        {
            int wea = InventoryMng.instance.UseWea;
            int adj = InventoryMng.instance.UseAdj;
            string WeaponName;
            if (adj > 0)
            {
                WeaponName = ((Adjective)adj).ToString() + "_" + ((Weapon)wea).ToString();
                WeaponName = WeaponName.ToLower();
            }
            else
            {
                WeaponName = ((Weapon)wea).ToString();
                WeaponName = WeaponName.ToLower();
            }
            for (int i = 0; i < S.Length; i++)
            {
                if (WeaponName == S[i].name)
                {
                    Debug.Log("욥욥욥욥욥욥 ::::   " + WeaponName);
                    InGameManager.instance.WinLoseText.text = "총알 발사 빵야빵야빠야빵빵빵";
                    WeaponObject = PhotonNetwork.Instantiate(WeaponName, transform.position, Quaternion.Euler(180f, 0f, 0f), 0);
                    WeaponObject.transform.parent = transform;

                    if (WeaponObject.tag == "SWORD" || WeaponObject.tag == "SHILED")
                    {
                        WeaponObject.transform.rotation = Quaternion.identity;
                    }

                   
                    WeaponObject.tag = "MYGUN";
                    GetComponent<Axis>().Weapon = WeaponObject;
                    Invoke("WeaponObjectFour", 2.0f);

                    //if (InGameManager.instance != null)
                    //{
                    //    InGameManager.instance._texttext.text = WeaponObject.transform.rotation + " - " + WeaponObject.GetComponentInChildren<fjfjfjfj>().transform.rotation;
                    //}
                    //    GetComponent<Axis>().enabled = true;

                }
            }
        }
        // Destroy(this);
    }
    public void WeaponObjectFour()
    {
        GameObject YouWeaponObject = GameObject.FindGameObjectWithTag("GUN");
        if(YouWeaponObject ==null)
        {
            YouWeaponObject = GameObject.FindGameObjectWithTag("SWORD");

            if (YouWeaponObject == null)
            {
                YouWeaponObject = GameObject.FindGameObjectWithTag("SHILED");
                YouWeaponObject.GetComponent<shield>().enabled = false;
                YouWeaponObject.transform.parent = InGameController.InGame.InGameInitScript.Player[1].GetComponentInChildren<InGameChangeWeapon>().transform;
            }
            else
            {
                YouWeaponObject.GetComponentInChildren<Sword>().enabled = false;
                YouWeaponObject.transform.parent = InGameController.InGame.InGameInitScript.Player[1].GetComponentInChildren<InGameChangeWeapon>().transform;
            }
        }
        else
        {
            YouWeaponObject.GetComponent<Gun>().enabled = false;
            YouWeaponObject.transform.parent = InGameController.InGame.InGameInitScript.Player[1].GetComponentInChildren<InGameChangeWeapon>().transform;
        }

    }
}
