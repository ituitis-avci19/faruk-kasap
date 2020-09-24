using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject LosePanel;
    public GameObject WinPanel;

    public int scene;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        if (scene >= 6)
        {
            MainMenu();
        }else
        {
            scene += 1;
            PlayerPrefs.SetInt("level" + scene, 1);
            SceneManager.LoadScene("Level" + scene);

        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void Restart()
    {
        SceneManager.LoadScene("Level" + scene);

    }
    public void MissionFailed()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void MissionCompleted()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
