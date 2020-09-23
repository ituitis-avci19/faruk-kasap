using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickPerson : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sickperson,tukuruk;
    public float tukurme_araligi,tukuruk_hizi;

    private float gecensure;
    void Start()
    {
        gecensure = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gecensure += Time.deltaTime;
        if(sickperson.name=="hastaf" || sickperson.name == "hasta_faruk_yaricap")
        {
            if (gecensure >= tukurme_araligi)
            {
                gecensure = 0;
                GameObject tuk = Instantiate(tukuruk) as GameObject;
                tuk.transform.position = sickperson.transform.position;
                float x = FindObjectOfType<movement>().dayi.transform.position.x - sickperson.transform.position.x;
                float y= FindObjectOfType<movement>().dayi.transform.position.y - sickperson.transform.position.y;
                float hipo = Mathf.Sqrt(x * x + y * y);
                float ratio = tukuruk_hizi / hipo;
                tuk.GetComponent<Rigidbody2D>().velocity = new Vector2(ratio * x, ratio * y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Destroy(sickperson);
        }
    }
}
