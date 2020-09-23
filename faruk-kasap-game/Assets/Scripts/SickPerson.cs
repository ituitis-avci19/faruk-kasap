using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickPerson : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sickperson;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Destroy(sickperson);
        }
    }
}
