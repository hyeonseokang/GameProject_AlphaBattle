using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBullet : MonoBehaviour
{

    public float BulletSpd = 0f;
    public float BulletDist = 0f;

    public GameObject par;

    // Use this for initialization
    void Start()
    {
        par = GameObject.Find("ExChar");
        transform.parent = par.transform;
        transform.localScale = new Vector3(1, 1, 1);
        Destroy(this.gameObject, 5f);

        //Destroy(this.gameObject, BulletDist);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * BulletSpd * Time.deltaTime);
    }
}
