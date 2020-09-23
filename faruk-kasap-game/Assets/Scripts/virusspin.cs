using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusspin : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 ScaleRange;
    public float scaleSpeed;

    public float rotateSpeed;

    int scaleway = 1;
    float scale = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y ,
            (transform.eulerAngles.z + (rotateSpeed * Time.deltaTime)) % 360);

        if (scaleway == 1)
        {
            scale += scaleSpeed * Time.deltaTime;
            if (scale >= ScaleRange.y)
            {
                scale = ScaleRange.y;
                scaleway = 2;
            }
        }else if (scaleway == 2)
        {
            scale -= scaleSpeed * Time.deltaTime;
            if (scale <= ScaleRange.x)
            {
                scale = ScaleRange.x;
                scaleway = 1;
            }
        }

        transform.localScale = new Vector3(scale, scale, 1);
    }
}
