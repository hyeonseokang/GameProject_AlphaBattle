using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {

    public GameObject blade;
    public GameObject Target;

    public float AtkSpd = 0f;
    public float AtkDist = 0f;

    bool IsSwing = false;
    int IsGone = 0;

    float Dist = 0f;

    GameObject a;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        weaponGo();

        Dist = Vector2.Distance(transform.position, transform.parent.position);

        if (Input.GetMouseButtonDown(0) && IsGone == 0)
        {
            IsGone = 1;
            
        }
    }

    void weaponGo()
    {

        if (IsGone == 1)
        {
            transform.Translate(Vector2.left * AtkSpd * Time.deltaTime);

            if (Dist >= AtkDist)
            {
                IsGone = 2;
                a = Instantiate(blade, null);
                a.transform.position = Target.transform.position;
                a.transform.rotation = Target.transform.rotation;
            }
        }
        else if (IsGone == 2)
        {
            transform.Translate(Vector2.right * AtkSpd * Time.deltaTime);

            if (Dist <= 1 && Dist >= -1)
            {
                transform.localPosition = new Vector2(0, 0);
                IsGone = 0;
            }
        }
    }
}
