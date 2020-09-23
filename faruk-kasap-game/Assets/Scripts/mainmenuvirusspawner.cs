using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuvirusspawner : MonoBehaviour
{

    public GameObject virus;
    public Vector2 intervalRange;
    public Vector2 xRange;



    private float time = 0.0f;
    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(intervalRange.x, intervalRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interval)
        {
            Instantiate(virus.gameObject, new Vector3(Random.Range(xRange.x, xRange.y), 8, 0), virus.transform.rotation);
            interval = Random.Range(intervalRange.x, intervalRange.y);
            time = 0.0f;
        }


    }
}
