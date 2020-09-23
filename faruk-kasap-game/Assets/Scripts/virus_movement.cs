using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius,korona_speed;
    public Rigidbody2D korona;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xfark = FindObjectOfType<movement>().dayi.transform.position.x - korona.position.x;
        float yfark = FindObjectOfType<movement>().dayi.transform.position.y - korona.position.y;
        if (Mathf.Sqrt(xfark * xfark + yfark * yfark) <= radius)
        {
            float hipo = Mathf.Sqrt(xfark * xfark + yfark * yfark);
            float ratio = korona_speed / hipo;
            korona.velocity = new Vector2(ratio * xfark, ratio * yfark);
        }
        else
        {
            korona.velocity = new Vector2(0, 0);
        }
    }
}
