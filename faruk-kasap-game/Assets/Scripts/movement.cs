using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dayi,bullet,cross_symbol;
    public Joystick joystick_mov,joystick_fire;
    public float speed,bullet_speed,atis_mesafesi,kirlilik_artis_hizi,max_kirlilik;
    public Image kirlilik_bari;
    public Sprite[] prof_sprites;
    public Color white,black;
    public GameObject[] mask_array;
    
    
    private Rigidbody2D rigbody;
    private int direction = 0, atisyapildi = 0,maske_var_mi=0;//0 mean left 1 mean right
    private Vector2 lastfirecoordinates;
    private float kirlilik;
 
    void Start()
    {
        maske_var_mi = 0;
        kirlilik = 0;
        atisyapildi = direction = 0;
        rigbody = dayi.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int kacibeyaz = maske_var_mi;
        int kacisiyah = 3 - maske_var_mi;
        for(int i = 0; i < kacibeyaz; i++)
        {
            mask_array[i].GetComponent<Image>().color = white;
        }
        for(int i = 2; i >= 3 - kacisiyah; i--)
        {
            mask_array[i].GetComponent<Image>().color = black;
        }
        if (maske_var_mi == 0)
        {
            dayi.GetComponent<SpriteRenderer>().sprite = prof_sprites[0];
        }
        else
        {
            dayi.GetComponent<SpriteRenderer>().sprite = prof_sprites[1];
        }
        kirlilik += kirlilik_artis_hizi*Time.deltaTime;
        kirlilik_bari.fillAmount = kirlilik / max_kirlilik;
        if (kirlilik >= max_kirlilik)
        {
            Debug.Log("GAME IS OVER!");
        }
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
            cross_symbol.SetActive(true);
            float x = joystick_fire.Horizontal;
            float y = joystick_fire.Vertical;
            float hipo = Mathf.Sqrt(x * x + y * y);
            float ratio = atis_mesafesi / hipo;
            //cross_symbol.transform.position = new Vector2(rigbody.position.x + atis_mesafesi * joystick_fire.Horizontal, rigbody.position.y + atis_mesafesi * joystick_fire.Vertical);
            cross_symbol.transform.position = new Vector2(rigbody.position.x + ratio * x, rigbody.position.y + ratio * y);
            atisyapildi = 1;
            lastfirecoordinates = new Vector2(joystick_fire.Horizontal, joystick_fire.Vertical);
        }
        else
        {
            cross_symbol.SetActive(false);
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
            float x = lastfirecoordinates.x;
            float y = lastfirecoordinates.y;
            float hipo = Mathf.Sqrt(x * x + y * y);
            float ratio = bullet_speed / hipo;

            rigofbullet.velocity = new Vector2(x*ratio, y*ratio);
        }
    }
}
