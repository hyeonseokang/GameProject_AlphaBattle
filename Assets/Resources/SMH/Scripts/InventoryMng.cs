using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapon
{
    EMPTY,
    FIST,
    SWORD,
    STICK,
    GUN,
    SHIELD
}

enum Adjective
{
    EMPTY,
    LONG,
    SHORT,
    STRONG,
    SUPERULTRA,
    SHARP,
    MAGIC
}

enum Individuality
{
    EMPTY,
    ZOMBIE, // 부활
    JOKER, // 랜덤능력
    HEYST, // 개빠름
    KLEPTOMANIA, // 상대 알파벳 훔침
    VAMPIRE, // 피흡


}


public class InventoryMng : MonoBehaviour {

    public static InventoryMng instance = null;

    public int[] Alpha = new int[26];
    
    public int UseWea;
    public int UseAdj;
    public int UseInd;
    
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
    


}
