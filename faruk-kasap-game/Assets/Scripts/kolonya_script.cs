using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolonya_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kolonya;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "dayi")
        {
            FindObjectOfType<movement>().kolonya_sayisi = 1;
            Destroy(kolonya);
        }
    }
}
