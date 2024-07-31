using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStick : MonoBehaviour {

    public GameObject Lightning;

    Vector3 MousePos;

    Animation MyAni;

    // Use this for initialization
    void Start () {
        MyAni = GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shake();
        }
    }

    void shake()
    {
        if (MyAni.isPlaying == false)
        {
            MyAni.Play();
            MakeLightning();
        }
    }

    void MakeLightning()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject L = Instantiate(Lightning, null);
        L.transform.position = new Vector3(MousePos.x, MousePos.y + 8, 0);
    }
}
