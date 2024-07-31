using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sieonvseov : MonoBehaviour {
    public GameObject chook;
    public GameObject Weapon;

    bool isShake = false;
	// Update is called once per frame
	void Update () {
        if(isShake)
        {
            Camera.main.transform.position = new Vector3(0,0,-10)+Random.insideUnitSphere * 0.15f;
        }
        Inpu2t();
    }
    IEnumerator asf()
    {
        isShake = true;
        yield return new WaitForSeconds(0.1f);
        isShake = false;
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }
    void Inpu2t()
    {
        float digree;
        Vector3 mousepos = (Input.mousePosition);
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int mouseposy;

        if (mousepos.x > Screen.width / 2)
        {
            mouseposy = 0;
            digree = Mathf.Atan2( chook.transform.position.y- target.y,
           transform.position.x - target.x) * +180f / Mathf.PI + 30;
        }
        else
        {
            mouseposy = 180;
            digree = Mathf.Atan2(target.y - chook.transform.position.y,
                 target.x - transform.position.x) * -180f / Mathf.PI + 30;
        }
        

        chook.transform.rotation = Quaternion.Euler(0, mouseposy, digree);


      //  chook.transform.rotation = Quaternion.Euler(0, mouseposy, mouseposz);
    }
}
