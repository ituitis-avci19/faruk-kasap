using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera_hareket : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 difference_with_dayi;
    public GameObject camera37;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera37.transform.position = FindObjectOfType<movement>().dayi.transform.position + difference_with_dayi;
    }
}
