using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAxis : MonoBehaviour
{
    public GameObject chook;
    public GameObject Weapon;

    public SpriteRenderer HeroSpr;

    public Camera cam;

    bool isShake = false;
    // Update is called once per frame
    void Update()
    {
        if (isShake)
        {
            cam.transform.position = new Vector3(0, 0, -10) + Random.insideUnitSphere * 0.15f;
        }
        Inpu2t();
    }
    IEnumerator asf()
    {
        isShake = true;
        yield return new WaitForSeconds(0.1f);
        isShake = false;
        cam.transform.position = new Vector3(0, 0, -10);
    }
    void Inpu2t()
    {
        float digree;
        Vector3 mousepos = (Input.mousePosition);
        Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
        int mouseposy;

        if (cam.ScreenToWorldPoint(Input.mousePosition).x - transform.parent.position.x > 0)
        {
            HeroSpr.flipX = true;

            mouseposy = 0;
            digree = Mathf.Atan2(chook.transform.position.y - target.y,
           transform.position.x - target.x) * +180f / Mathf.PI + 30;
        }
        else
        {
            HeroSpr.flipX = false;

            mouseposy = 180;
            digree = Mathf.Atan2(target.y - chook.transform.position.y,
                 target.x - transform.position.x) * -180f / Mathf.PI + 30;
        }


        chook.transform.rotation = Quaternion.Euler(0, mouseposy, digree - 32);


        //  chook.transform.rotation = Quaternion.Euler(0, mouseposy, mouseposz);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(HeroSpr.flipX);
        }
        else
        {
            this.HeroSpr.flipX = (bool)stream.ReceiveNext();
        }
    }
}
