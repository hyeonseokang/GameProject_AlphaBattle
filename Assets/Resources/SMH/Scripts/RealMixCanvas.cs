using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RealMixCanvas : MonoBehaviour {

    public Image ajaj;
    int[] Alpha = new int[26];
    int[] TempAlpha = new int[26];

    public Text[] KeyboardText = new Text[26];
    public Text[] KeyboardNumText = new Text[26];

    public GameObject WordParent;
    public GameObject WordParent2;

    string bench;

    public InputField BenchText;

    public Text Timer;
    float time;

    public GameObject ErrorMsg;

    private Rect windowRect = new Rect(0, 0, 1920, 1080);
    // Only show it if needed.
    private bool show = false;

    private bool isMyReady = false;
    private bool isYouReady = false;



    // Use this for initialization
    void Start () {
        
        
        time = 60;

        Alpha = InventoryMng.instance.Alpha;
        
        for(int i=0; i<26; i++)
        {
            KeyboardText[i].text = ((char)(65 + i)).ToString();
            
            string tempstr = string.Empty;
            tempstr += (char)(65 + i);
            KeyboardText[i].GetComponentInParent<Button>().onClick.AddListener(() => SelectBtn(tempstr));
        }

        CanvasMng.instance.MList.Clear();
        CanvasMng.instance.MList2.Clear();

        CanvasMng.instance.MList.Add(GameObject.Find("FIST(Clone)").GetComponentInChildren<MoveAndMix>());

        for(int i=0; i<CanvasMng.instance.HList.Count; i++)
        {
            bench = CanvasMng.instance.HList[i];
            Makeword();
        }
        for (int i = 0; i < CanvasMng.instance.HList2.Count; i++)
        {
            bench = CanvasMng.instance.HList2[i];
            Makeword();
        }

        CanvasMng.instance.HList.Clear();
        CanvasMng.instance.HList2.Clear();



        Image[] TempImage = GameObject.Find("WeaponInventory").GetComponentsInChildren<Image>();


        Image[] TempImage2 = GameObject.Find("IndividualityInventory").GetComponentsInChildren<Image>();


        for (int i = 0; i < TempImage.Length ; i++)
        {
            CanvasMng.instance.WeaponInventory[i] = TempImage[i];
        }
        for (int i = 0; i < TempImage2.Length ; i++)
        {
            CanvasMng.instance.IndividualityInventory[i] = TempImage2[i];
        }
    }
    public void enfen()
    {
        PhotonNetwork.LoadLevel("New Scene");
    }
    // Update is called once per frame
    void Update()
    {
        BenchText.text = bench;

        Timer.text = ((int)(time -= Time.deltaTime)).ToString();

        if (time <= 0)
        {
            SaveData();
            ajaj.GetComponent<Animator>().SetTrigger("rkrk");
            Invoke("enfen", 1.0f);
        }
            for (int i = 0; i < 26; i++)
            {
                KeyboardNumText[i].text = Alpha[i].ToString();
            }


        
    }


    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.type.ToString() == "keyDown")
        {
            if (e.keyCode == KeyCode.Return)
            {
                Makeword();
            }
            else if (e.keyCode >= KeyCode.A && e.keyCode <= KeyCode.Z)
            {
                SelectBtn(e.keyCode.ToString().ToUpper());

                for (int i = 0; i < 26; i++)
                {
                    if (e.keyCode.ToString().ToUpper() == KeyboardText[i].text)
                    {
                        KeyboardText[i].GetComponentInParent<Image>().color = Color.gray;
                        StartCoroutine(ReturnColor(KeyboardText[i].GetComponentInParent<Image>()));
                    }
                }
            }
            else if(e.keyCode == KeyCode.Backspace && bench.Length > 0)
            {
                DeleteBtn();
            }
            
        }
    }

    IEnumerator ReturnColor(Image aa)
    {
            yield return new WaitForSeconds(0.15f);
            aa.color = Color.white;
    }

    public void DeleteBtn()
    {
        int num = Convert.ToChar(bench.Substring(bench.Length-1)) - 65;
        
        bench = bench.Substring(0, bench.Length - 1);


        Alpha[num] += 1;
        TempAlpha[num] -= 1;

    }

    public void SelectBtn(string c)
    {
        
        int num = Convert.ToChar(c)-65;
        

        if (Alpha[num] > 0 && num >=0 && num <=25)
        {
            Alpha[num] -= 1;
            TempAlpha[num] += 1;
            bench += c;
            SoundManger.instance.Play(AudioEnum.CLICK);
        }
        else
        {
            ErrorMsg.SetActive(true);
        }
        Debug.Log(bench);
    }
    
    public void MsgDown()
    {
        ErrorMsg.SetActive(false);
    }

    public void Makeword()
    {
        switch (bench)
        {
            case "STRONG":
                CreateWord(bench, (int)Adjective.STRONG, "Adjective");
                break;

            case "LONG":
                CreateWord(bench, (int)Adjective.LONG, "Adjective");
                break;

            case "SHARP":
                CreateWord(bench, (int)Adjective.SHARP, "Adjective");
                break;

            case "SHORT":
                CreateWord(bench, (int)Adjective.SHORT, "Adjective");
                break;

            case "MAGIC":
                CreateWord(bench, (int)Adjective.MAGIC, "Adjective");
                break;

            case "SWORD":
                CreateWord(bench, (int)Weapon.SWORD, "Weapon");
                break;

            case "GUN":
                CreateWord(bench, (int)Weapon.GUN, "Weapon");
                break;

            case "STICK":
                CreateWord(bench, (int)Weapon.STICK, "Weapon");
                break;

            case "SHIELD":
                CreateWord(bench, (int)Weapon.SHIELD, "Weapon");
                break;
                
            case "HYEST":
                CreateWord(bench, (int)Individuality.HEYST, "Individuality");
                break;

            default:
                {
                    for (int i = 0; i < 26; i++)
                    {
                        Alpha[i] += TempAlpha[i];
                    }
                    break;
                }

        }
        ResetBench();
        
    }

    void CreateWord(string s, int num, string aa)
    {
        string path = "SMH/Prefabs/" + aa.ToString() + "/" + s;
        Debug.Log(path);
        GameObject prefab = Resources.Load(path) as GameObject;
        GameObject TempGame = Instantiate(prefab) as GameObject;

        if(aa == "Weapon" || aa == "Adjective")
            TempGame.transform.parent = WordParent.transform;
        else
            TempGame.transform.parent = WordParent2.transform;

        if (aa == "Weapon")
        {
            TempGame.GetComponentInChildren<MoveAndMix>().wea = num;
            CanvasMng.instance.MList.Add(TempGame.GetComponentInChildren<MoveAndMix>());

        }
        else if (aa == "Adjective")
        {
            TempGame.GetComponentInChildren<MoveAndMix>().adj = num;
            CanvasMng.instance.MList.Add(TempGame.GetComponentInChildren<MoveAndMix>());
        }
        else if (aa == "Individuality")
        {   
            TempGame.GetComponentInChildren<MoveAndMix>().ind = num;
            CanvasMng.instance.MList2.Add(TempGame.GetComponentInChildren<MoveAndMix>());
        }

        

    }

    void ResetBench()
    {
        Debug.Log(bench);
        Debug.Log(BenchText);
        bench = string.Empty;
        BenchText.text = null;
        for (int i = 0; i < 26; i++)
        {
            TempAlpha[i] = 0;
        }

        Debug.Log(bench);
        Debug.Log(BenchText);
    }

    public void SaveData()
    {
        for (int i = 0; i < CanvasMng.instance.MList.Count; i++)
        {
            if (CanvasMng.instance.MList[i].IsUse)
            {
                CanvasMng.instance.MList.Remove(CanvasMng.instance.MList[i]);
            }
        }

        for (int i = 0; i < CanvasMng.instance.MList2.Count; i++)
        {
            if (CanvasMng.instance.MList2[i].IsUse)
            {
                CanvasMng.instance.MList2.Remove(CanvasMng.instance.MList2[i]);
            }
        }

        for (int i = 0; i < CanvasMng.instance.MList.Count; i++)
        {
            string[] TempStirng;
            TempStirng = CanvasMng.instance.MList[i].transform.parent.name.Split('(');

            CanvasMng.instance.HList.Add(TempStirng[0]);
        }
        for (int i = 0; i < CanvasMng.instance.MList2.Count; i++)
        {
            string[] TempStirng;
            TempStirng = CanvasMng.instance.MList2[i].transform.parent.name.Split('(');

            CanvasMng.instance.HList2.Add(TempStirng[0]);
        }
    }

    public void ReadyButtonGo()
    {
        SoundManger.instance.Play(AudioEnum.CLICK);
        GetComponent<PhotonView>().RPC("ReadyButton", PhotonTargets.All, PhotonNetwork.player);
    }
    [PunRPC]
    void ReadyButton(PhotonPlayer _player)
    {
        if (_player == PhotonNetwork.player)
            isMyReady = true;
        else
            isYouReady = true;

        if (isMyReady && isYouReady)
        {
            SaveData();
            PhotonNetwork.LoadLevel("New Scene");
        }
    }
}
