using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dayi,bullet;
    public Joystick joystick_mov,joystick_fire;
    public float speed,bullet_speed;

    private Rigidbody2D rigbody;
    private int direction = 0,atisyapildi=0;//0 mean left 1 mean right
    private Vector2 lastfirecoordinates;
    void Start()
    {
        atisyapildi = direction = 0;
        rigbody = dayi.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigbody.velocity = new Vector2(speed * joystick_mov.Horizontal, speed * joystick_mov.Vertical);
        if (joystick_mov.Horizontal > 0 && direction==0)
        {
            direction = 1;
            rigbody.transform.Rotate(0, 180 ,0);
        }
        if (joystick_mov.Horizontal <0 && direction == 1)
        {
            direction = 0;
            rigbody.transform.Rotate(0, 180, 0);
        }
        if(joystick_fire.Horizontal!=0 || joystick_fire.Vertical != 0)
        {
            atisyapildi = 1;
            lastfirecoordinates = new Vector2(joystick_fire.Horizontal, joystick_fire.Vertical);
        }
        if(joystick_fire.Horizontal==0 && joystick_fire.Vertical == 0 && atisyapildi==1)
        {
            atisyapildi = 0;
            GameObject mermi;
            Vector2 konum = rigbody.transform.position; ;
            mermi=Instantiate(bullet) as GameObject;
            mermi.transform.position = konum;
            Rigidbody2D rigofbullet;
            rigofbullet = mermi.GetComponent<Rigidbody2D>();
            rigofbullet.velocity = new Vector2(lastfirecoordinates.x * bullet_speed, lastfirecoordinates.y * bullet_speed);
        }
    }
}
