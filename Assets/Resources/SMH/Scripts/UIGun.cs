using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGun : MonoBehaviour
{
    public GameObject Bullet;

    public float AtkDelay = 0.5f;
    public float reaction;
    public float ReloadDelay = 0f;
    public float BulletSpd = 0f;
    public float BulletDist = 0f;

    public int BulletCount = 0;
    public int OriginBullet = 0;
    public int Bulletnum = 0;
    public int Damage = 0;

    float ReloadTimer = 0f;
    float AtkTimer;
    float randomf;

    GameObject Target;


    bool ReloadBool = false;

    // Use this for initialization
    void Start()
    {
        Target = transform.Find("Target").gameObject;
        BulletCount = OriginBullet;

        Bullet.GetComponent<UIBullet>().BulletSpd = BulletSpd;
        Bullet.GetComponent<UIBullet>().BulletDist = BulletDist;

        AtkTimer = AtkDelay;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Reload();

        if (Input.GetKeyDown(KeyCode.R) && BulletCount != OriginBullet && !ReloadBool)
            ReloadBool = true;
    }

    void Shoot()
    {
        if (BulletCount > 0)
        {
            if (!ReloadBool)
            {
                if (Input.GetMouseButton(0))
                {
                    if (AtkTimer > AtkDelay)
                    {
                        BulletCount--;

                        for (int i = 0; i < Bulletnum; i++)
                            CreateBullet();
                    }
                }
                AtkTimer += Time.deltaTime;
            }
        }

        else
        {
            //소리만 남
        }
    }

    void CreateBullet()
    {
        randomf = Random.RandomRange(90 - reaction, 90 + reaction);

        Target.transform.localEulerAngles = new Vector3(0, 0, randomf);

        Instantiate(Bullet, Target.transform.position, Target.transform.rotation);
        AtkTimer = 0;
    }

    void Reload()
    {
        if (ReloadBool)
        {
            ReloadTimer += Time.deltaTime;

            if (ReloadDelay < ReloadTimer)
            {
                BulletCount = OriginBullet;
                ReloadTimer = 0;
                AtkTimer = AtkDelay;
                ReloadBool = false;
                return;
            }
        }
    }
}
