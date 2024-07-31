using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private bool check = true;
    private float checkTime;
    private Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 15 * Time.deltaTime);
            if (transform.position == targetPos)
            {
                checkTime += Time.deltaTime;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                if (checkTime >= 0.2f)
                {
                    GetComponent<Rigidbody2D>().gravityScale = 2;
                    check = !check;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (!check)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                AlphabetManger.instance.check = false;
            }
        }
    }
}
