using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(iiii))]
public class CreateWord : Editor
{
    iiii p;

    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        if (p == null) p = (iiii)target;

        base.OnInspectorGUI();


        p.hp = EditorGUILayout.IntField("ffuck", p.hp);

        p.mp = EditorGUILayout.Slider("fffucksl", p.mp, 0, 100);

        Vector3 ppp = new Vector3(p.xx, p.yy, p.zz);


        ppp = EditorGUILayout.Vector3Field("xxyyzz", ppp);

        p.xx = (int)ppp.x;
        p.yy = (int)ppp.y;
        p.zz = (int)ppp.z;


        if (GUILayout.Button("fffuckButton"))
        {
            p.hp = 500;
        }

        if (GUILayout.Button("fffuckButton2222"))
        {
            GameObject newobj = p.Btn;
            
            p.Btn.GetComponentInChildren<Text>().text = p.InputText.text;
            newobj.name = p.InputText.text + "Btn";
            newobj.GetComponent<Image>().sprite = p.spr;
            string localPath = "Assets/Resources/Prefabs/" + newobj.name + ".prefab";
            Object prefab = PrefabUtility.CreatePrefab(localPath, newobj);
            PrefabUtility.ReplacePrefab(newobj, prefab, ReplacePrefabOptions.ConnectToPrefab);

        }

    }

    void OnSceneGUI()
    {
        if (p == null) p = (iiii)target;

        if (p.ffffuckArray.Length == 0) return;


        for (int i = 0; i < p.ffffuckArray.Length; i++)
        {
            //Handles.DrawLine(p.transform.position, p.ffffuckArray[i].transform.position, Color.cyan);
            Handles.DrawLine(p.transform.position, p.ffffuckArray[i].transform.position);

        }

    }


}


