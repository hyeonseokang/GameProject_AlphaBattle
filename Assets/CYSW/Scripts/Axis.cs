using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    public GameObject chook;
    public GameObject Weapon;

    public SpriteRenderer HeroSpr;

    bool isShake = false;
    void Update()
    {
        if (isShake)
        {
            Camera.main.transform.position = new Vector3(0, 0, -10) + Random.insideUnitSphere * 0.15f;
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
        Vector3 target = Camera.main.ScreenToWorldPoint(mousepos);
        int mouseposy;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.parent.position.x > 0)
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
        //if (InGameManager.instance != null&& Weapon!=null)
        //    InGameManager.instance._texttext.text = "마우스 :  " + mouseposy + "   각도 : " + digree + "오브 : " + Weapon.transform.rotation.z + " x: " + Weapon.transform.rotation.x;

        //if (InGameManager.instance != null && Weapon != null)
        //{
        //    InGameManager.instance._texttext.text = Camera.main.ScreenToWorldPoint(Input.mousePosition).x + " 김화온 :: " + transform.parent.position.x;
        //    InGameManager.instance._tex.text = chook.transform.eulerAngles + " - " + chook.GetComponentInChildren<fjfjfjfj>().transform.eulerAngles;
        //}

        chook.transform.rotation = Quaternion.Euler(0, mouseposy, digree - 32);


        //  chook.transform.rotation = Quaternion.Euler(0, mouseposy, mouseposz);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(chook.transform.rotation);
            stream.SendNext(HeroSpr.flipX);
        }
        else
        {
            this.chook.transform.rotation = (Quaternion)stream.ReceiveNext();
            this.HeroSpr.flipX = (bool)stream.ReceiveNext();
        }
    }
}
