using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public GameObject Blade;
    public GameObject Target;

    public float AtkDelay = 0f;
    bool IsSwung = false;

    public float downZ = 0f;
    public Vector3 downVec = Vector3.zero;

    public float upZ = 0f;
    public Vector3 upVec = Vector3.zero;

    public SpriteRenderer swordSpr;

	// Use this for initialization
	void Start () {
        Blade.GetComponent<Blade>().Delay = AtkDelay;

       // Invoke("SwingDown", 3.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            Swing();
	}

    void Swing()
    {
        if (GameObject.Find("Blade") == null)
        {
            SoundManger.instance.Play(AudioEnum.SWORD);
            if (!IsSwung)
            {
                SwingDown();
            }
            else
            {
                SwingUp();
            }
        }
    }

    void SwingDown()
    {
        GameObject blade = PhotonNetwork.Instantiate(Blade.name, Target.transform.position, Target.transform.rotation, 0);
        blade.tag = "fish";

        blade.transform.position = Target.transform.position;
        blade.transform.rotation = Target.transform.rotation;

        transform.localRotation = Quaternion.Euler(0, 0, upZ);
        transform.localPosition = upVec;
        IsSwung = true;

        swordSpr.sortingOrder = 30;
    }

    void SwingUp()
    {
        GameObject blade = Instantiate(Blade, null);
        blade.transform.position = Target.transform.position;
        blade.transform.rotation = Target.transform.rotation;

        transform.localRotation = Quaternion.Euler(0,0,downZ);
        transform.localPosition = downVec;
        IsSwung = false;

        swordSpr.sortingOrder = 1;
    }
}
