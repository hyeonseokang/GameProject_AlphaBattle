using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;

    Text ReloadText;
    Text BulletCountText;

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

    public float Rt
    {
        get
        {
            return ReloadTimer;
        }
    }

    float AtkTimer;
    float randomf;

    GameObject Target;


    bool ReloadBool = false;

    public AudioClip GunSource;
    public AudioClip Jangjung;
    // Use this for initialization
    void Start()
    {
        GameObject Canvas;
        Canvas = GameObject.Find("Canvas");

        BulletCountText = GameObject.Find("BC").GetComponent<Text>();
        ReloadText = GameObject.Find("RT").GetComponent<Text>();

        Target = transform.Find("Target").gameObject;
        BulletCount = OriginBullet;

        Bullet.GetComponent<Bullet>().BulletSpd = BulletSpd;
        Bullet.GetComponent<Bullet>().BulletDist = BulletDist;

        AtkTimer = AtkDelay;
    }

    // Update is called once per frame
    void Update()
    {
        BulletCountText.text = "" + BulletCount;
        ReloadText.text = "" + (ReloadDelay - ReloadTimer);

        Shoot();
        Reload();

        if (Input.GetKeyDown(KeyCode.R) && BulletCount != OriginBullet && !ReloadBool)
        {
   
            ReloadBool = true;
        }
    }

    void UpdateText()
    {
        
    }

    void Shoot()
    {
        if (BulletCount * Bulletnum > 0)
        {
            if (!ReloadBool)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (AtkTimer > AtkDelay)
                    {
                        GetComponent<AudioSource>().PlayOneShot(GunSource);
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
        randomf = Random.Range(90 - reaction, 90 + reaction);

        Target.transform.localEulerAngles = new Vector3(0, 0, randomf);

        //Instantiate(Bullet, Target.transform.position, Target.transform.rotation);

        GameObject aa = PhotonNetwork.Instantiate("Bullet", Target.transform.position, Target.transform.rotation,0);
        aa.tag = "fish";
        AtkTimer = 0;
    }

    void Reload()
    {
        if (ReloadBool)
        {
            GetComponent<AudioSource>().PlayOneShot(Jangjung);
            SoundManger.instance.Play(AudioEnum.CHULKUK);
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
