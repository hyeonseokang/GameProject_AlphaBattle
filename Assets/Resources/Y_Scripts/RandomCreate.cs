using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour {
    public GameObject[] FarmObj;
    public List<Vector3> Pos = new List<Vector3>();
    //public Sprite[] item;
    // Use this for initialization


    void Start () {
        create();
    }

	
	// Update is called once per frame
	void Update () {

    }

    void create()
    {
        for (int i = 0; i < 25; i++) 
        {
            int j = Random.Range(0, Pos.ToArray().Length);
            GameObject farm = Instantiate(FarmObj[i], Pos[j], transform.rotation);
            Pos.Remove(Pos[j]);
            farm.transform.parent = transform;
        }
    }
}
