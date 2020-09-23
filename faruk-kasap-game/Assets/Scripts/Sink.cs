using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{

    public GameObject tap;

    // Start is called before the first frame update
    void Start()
    {
        CloseTap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTap()
    {
        tap.SetActive(true);

    }
    public void CloseTap()
    {
        tap.SetActive(false);
    }


}
