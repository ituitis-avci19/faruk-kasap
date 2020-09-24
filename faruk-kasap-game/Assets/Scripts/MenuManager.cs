using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Sprite lockedButton;
    public Sprite unlockedButton;

    public GameObject levelMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("level1"))
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerPrefs.SetInt("level" + (i + 1), 0);
            }
            PlayerPrefs.SetInt("level1", 1);
        }

        for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetInt("level" + i) == 1) {
                GameObject.Find("" + i).GetComponent<Image>().sprite = unlockedButton;
                GameObject.Find("Text" + i).GetComponent<Text>().text = "" + i;

            }
            else {
                GameObject.Find("" + i).GetComponent<Image>().sprite = lockedButton;
            }
        }

        levelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevel(int level)
    {
        if (PlayerPrefs.GetInt("level" + level) == 1)
        {
            SceneManager.LoadScene("Level" + level);
        }
    }
    public void backButton()
    {
        levelMenu.SetActive(false);
    }
    public void playButton()
    {
        levelMenu.SetActive(true);
    }
}
