using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmObj : MonoBehaviour
{
    public int hp = 0;
    public Sprite[] FSpt;
    public GameObject Ani;
    public GameObject item;
    private int j = 0;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        DieObj();
    }

    private void DieObj()
    {
        if (hp >= 4 )
        {
            Vector3 tempos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Destroy(gameObject);
            GameObject ani = Instantiate(Ani, tempos, transform.rotation);
            Destroy(ani, 0.35f);
            if (transform.gameObject.name.Length <= 3 + 7)
            {
                for (int i = 0; i < 2; i++)
                {
                    CreateAlphabet();
                }
            }

            if (transform.gameObject.name.Length >= 4 + 7
                && transform.gameObject.name.Length <= 5 + 7)
            {
                for (int i = 0; i < 3; i++)
                {
                    CreateAlphabet();

                }
            }

            if (transform.gameObject.name.Length >= 6 + 7
                 && transform.gameObject.name.Length <= 8 + 7)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateAlphabet();
                }
            }

            if (transform.gameObject.name.Length >= 9 + 7)
            {
                for (int i = 0; i < 5; i++)
                {
                    CreateAlphabet();
                }
            }
        }
    }

    public void CreateAlphabet()
    {
        if (transform.gameObject.name == "Chair(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Chair.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Chair[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Chair.Remove(AlphabetManger.instance.Chair[j]);

            //if (temp.name.Length >= 9 + 7)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Computer(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Computer.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Computer[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Computer.Remove(AlphabetManger.instance.Computer[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Gold(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Gold.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Gold[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Gold.Remove(AlphabetManger.instance.Gold[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Key(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Key.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Key[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Key.Remove(AlphabetManger.instance.Key[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Money(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Money.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Money[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Money.Remove(AlphabetManger.instance.Money[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Table(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Table.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Table[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Table.Remove(AlphabetManger.instance.Table[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Television(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Television.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Television[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Television.Remove(AlphabetManger.instance.Television[j]);

            //if(temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        } 

        if (transform.gameObject.name == "Vase(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Vase.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Vase[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Vase.Remove(AlphabetManger.instance.Vase[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if(transform.gameObject.name == "Refrigerator(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Refrigerator.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Refrigerator[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Refrigerator.Remove(AlphabetManger.instance.Refrigerator[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Sofa(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Sofa.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Sofa[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Sofa.Remove(AlphabetManger.instance.Sofa[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Oven(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Oven.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Oven[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Oven.Remove(AlphabetManger.instance.Oven[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Microwave(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Microwave.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Microwave[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Microwave.Remove(AlphabetManger.instance.Microwave[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }

        if (transform.gameObject.name == "Airconditional(Clone)")
        {
            int j = 0;
            int k = 0;
            j = Random.Range(0, AlphabetManger.instance.Airconditional.ToArray().Length);
            GameObject temp = Instantiate(item, transform.position,
                transform.rotation) as GameObject;
            temp.GetComponent<SpriteRenderer>().sprite = AlphabetManger.instance.Airconditional[j];
            k = Random.Range(-4, 4);
            temp.transform.position = new Vector3(temp.transform.position.x + k, temp.transform.position.y + 1f
                , transform.position.z);
            //temp.name = temp.name.Substring(0, 2);
            temp.name = temp.GetComponent<SpriteRenderer>().sprite.name;
            AlphabetManger.instance.Airconditional.Remove(AlphabetManger.instance.Airconditional[j]);

            //if (temp.name.Length >= 9)
            //{
            //    temp.name = temp.name.Substring(0, 2);
            //}

            //else
            //{
            //    temp.name = temp.name.Substring(0, 1);
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = FSpt[hp];
            hp++;
        }
    }
}