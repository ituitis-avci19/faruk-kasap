using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tukuruk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tuktuk;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible()
    {
        Destroy(tuktuk);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mermiyiyoket" && collision.name!="hasta_faruk_yaricap" && collision.name!="hastaf")
            Destroy(tuktuk);
        
    }
}
