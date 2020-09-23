using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask_collision_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mask;
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
            FindObjectOfType<movement>().maske_var_mi=Mathf.Min(FindObjectOfType<movement>().maske_var_mi+1,3);
            Destroy(mask);
        }
    }
}
