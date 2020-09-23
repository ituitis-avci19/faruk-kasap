using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletgo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible()
    {
        Destroy(bulletgo);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="mermiyiyoket")
            Destroy(bulletgo);
        if(collision.name== "tukuruk(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }
}
