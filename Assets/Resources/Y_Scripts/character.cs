using UnityEngine;

public class character : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    public Sprite[] FSpt;
    public Sprite[] Alphabet;
    public GameObject nullobj;
    public Collider2D[] hitColliders;
    private Vector3 target;
    //private bool check;
    // Use this for initialization
    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //check = GetComponent<DropItem>().check;
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void FixedUpdate()
    {
        target = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        item();
    }

    private void item()
    {

        if (!AlphabetManger.instance.check)
        {
            hitColliders = Physics2D.OverlapCircleAll(transform.position, 4.5f);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].CompareTag("item"))
                {
                    hitColliders[i].transform.position = Vector3.MoveTowards(hitColliders[i].transform.position,
                        target, 5f * Time.deltaTime);
                }
            }
        }
    }

    public AudioSource audiosource;
    public AudioClip _aa;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item")) 
        {
            if (!AlphabetManger.instance.check)
            {
                SoundManger.instance.Play(AudioEnum.EAT);
                string s = collision.gameObject.name;
                int i = int.Parse(s);
                InventoryMng.instance.Alpha[i]++;
                Destroy(collision.gameObject);
            }
        }
    }
}