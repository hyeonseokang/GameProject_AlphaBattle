using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MoveAndMix : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Button A;
    public ChangeWeapon ch;
    public GameObject MakeEffect;

    bool mouseDown;

    float TimeInterval;

    public int wea;
    public int adj;
    public int ind;

    public bool IsCrush;
    public bool IsUse;

    public Collider2D CrushCollider;

    public GameObject WordParent;
    public GameObject cam;
    // Use this for initialization
	void Start () {
        
        if(MakeEffect != null)
        Destroy(Instantiate(MakeEffect,transform),0.8f);
        

        WordParent = GameObject.Find("WeaponInventoryWord");
        //ch = GameObject.Find("Axis").GetComponent<ChangeWeapon>();
        cam = GameObject.Find("UICamera");
        TimeInterval = -10f;
	}
	
	// Update is called once per frame
	void Update () {

        if (mouseDown && ind == 0)
            A.transform.position = new Vector3(cam.transform.position.x + Input.mousePosition.x - Screen.width/2 , cam.transform.position.y +  Input.mousePosition.y - Screen.height/2);    

        //각 칸마다 정보를 담기
    }
    


    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.time - TimeInterval < 0.5f && ((wea > 0) || ind >0))
        {
            if (ind > 0)
            {
                CanvasMng.instance.Reset2();
                InventoryMng.instance.UseInd = ind;
                
            }
                else if(ind == 0)
            {
                CanvasMng.instance.Reset();
                InventoryMng.instance.UseWea = wea;
                InventoryMng.instance.UseAdj = adj;
            }

            

            IsUse = true;

            //ch.ChangeWea();
                   
        }


        TimeInterval = Time.time;
        
        mouseDown = true;
        Debug.Log("start");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;

        if (IsCrush)
            Mix(CrushCollider);

        else
        {
            transform.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
        }
        Debug.Log("end");
    }

    void Mix(Collider2D col)
    {
        if (mouseDown == false)
        {
            string[] split_text;
            string[] split_text2;

            if (adj > 0)
            {
                split_text = transform.parent.name.Split('(');
                split_text2 = col.transform.parent.name.Split('(');
                split_text[0].TrimEnd();
                split_text2[0].TrimEnd();
            }
            else
            {
                split_text = col.transform.parent.name.Split('(');
                split_text2 = transform.parent.name.Split('(');
                split_text[0].TrimEnd();
                split_text2[0].TrimEnd();
            }

            string MixName = split_text[0] + split_text2[0];

            string path = "SMH/Prefabs/Mix/" + MixName;
            Debug.Log(path);
            GameObject prefab = Resources.Load(path) as GameObject;

            if (prefab != null)
            {
                GameObject TempGame = Instantiate(prefab) as GameObject;
                MoveAndMix M = TempGame.GetComponentInChildren<MoveAndMix>();
                
                TempGame.transform.parent = WordParent.transform;
                if (adj > 0)
                {
                    M.wea = col.GetComponent<MoveAndMix>().wea;
                    M.adj = adj;
                }

                else
                {
                    M.wea =wea;
                    M.adj = col.GetComponent<MoveAndMix>().adj;
                }

                CanvasMng.instance.Reset();

                InventoryMng.instance.UseWea = M.wea;
                InventoryMng.instance.UseAdj = M.adj;
                
                TempGame.GetComponentInChildren<MoveAndMix>().IsUse = true;
               // ch.ChangeWea();
                CanvasMng.instance.MList.Add(TempGame.GetComponentInChildren<MoveAndMix>());

                


                Destroy(col.transform.parent.gameObject);
                Destroy(transform.parent.gameObject);

                CanvasMng.instance.MList.Remove(col.transform.GetComponent<MoveAndMix>());
                CanvasMng.instance.MList.Remove(transform.GetComponent<MoveAndMix>());

            }
            else
            {
                transform.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            }




        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        CrushCollider = col;
        IsCrush = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        CrushCollider = null;
        IsCrush = false;

    }




}
