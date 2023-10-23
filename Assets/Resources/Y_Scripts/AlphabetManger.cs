using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetManger : MonoBehaviour {
    public static AlphabetManger instance = null;
    public bool check = true;
    public Sprite[] spr;
    public List<Sprite> Computer = new List<Sprite>();
    public List<Sprite> Chair = new List<Sprite>();
    public List<Sprite> Gold = new List<Sprite>();
    public List<Sprite> Key = new List<Sprite>();
    public List<Sprite> Money = new List<Sprite>();
    public List<Sprite> Table = new List<Sprite>();
    public List<Sprite> Vase = new List<Sprite>();
    public List<Sprite> Television = new List<Sprite>();
    public List<Sprite> Airconditional = new List<Sprite>();
    public List<Sprite> Microwave = new List<Sprite>();
    public List<Sprite> Oven = new List<Sprite>();
    public List<Sprite> Refrigerator = new List<Sprite>();
    public List<Sprite> Sofa = new List<Sprite>();

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
