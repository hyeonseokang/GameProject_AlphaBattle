using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CanvasMng : MonoBehaviour {
    
    public static CanvasMng instance = null;

    public Sprite On;
    public Sprite Off;


  //  [HideInInspector]
    public Image[] WeaponInventory = new Image[10];

    //[HideInInspector]
    public Image[] IndividualityInventory = new Image[5];

    
    public List<MoveAndMix> MList = new List<MoveAndMix>();
    
    public List<MoveAndMix> MList2 = new List<MoveAndMix>();
    
    public List<string> HList = new List<string>();
    
    public List<string> HList2 = new List<string>();

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {

            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(WeaponInventory[0]!=null)
        {
            if (WeaponInventory[0].sprite == null)
            {
                enabled = false;
            }
            else
            {
                enabled = true;
            }
        }
     
    }

    // Update is called once per frame
    void Update () {

        for (int i = 0; i < MList.Count; i++)
        {
         
                if (MList[i].IsUse)
                {
                    WeaponInventory[i].sprite = On;
                    WeaponInventory[i].SetNativeSize();
                }
                else
                {
                    WeaponInventory[i].sprite = Off;
                    WeaponInventory[i].SetNativeSize();
                }
            
        }
        for (int i = 0; i < MList2.Count; i++)
        {
            if (MList2[i].IsUse)
            {
                IndividualityInventory[i].sprite = On;
                IndividualityInventory[i].SetNativeSize();
            }
            else
            {
                IndividualityInventory[i].sprite = Off;
                IndividualityInventory[i].SetNativeSize();
            }
        }
    }

    public void Reset()
    {
        for(int i =0; i<MList.Count; i++)
        {
            MList[i].IsUse = false;
        }
        for(int i =0; i<WeaponInventory.Length; i++)
        {
            WeaponInventory[i].sprite = Off;
            WeaponInventory[i].SetNativeSize();
        }
    }
    public void Reset2()
    {
        for (int i = 0; i < MList2.Count; i++)
        {
            MList2[i].IsUse = false;
        }
        for (int i = 0; i < IndividualityInventory.Length; i++)
        {
            IndividualityInventory[i].sprite = Off;
            IndividualityInventory[i].SetNativeSize();
        }
    }

}
