using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageLoseMenu : MonoBehaviour {

    public Button restartButton;
    public Button quitButton;
    public Text timeText;
    public GameObject player;
    public GameObject spawner;
    public GameObject seatTracker;
    public GameObject timeTracker;

    void Start () {
        timeTracker.SetActive(false);
        seatTracker.SetActive(false);
        spawner.SetActive(false);
        player.SetActive(false);
        
        Button resBtn = restartButton.GetComponent<Button>();
        resBtn.onClick.AddListener(RestartGame);

        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(QuitGame);

        int seconds = timeTracker.GetComponent<TrackTime>().GetTimePassed();
        int minutes = seconds / 60;
        int leftoverSeconds = seconds % 60;
        timeText.GetComponent<Text>().text = (minutes < 10 ? "0" : "") + minutes + ":" + (leftoverSeconds < 10 ? "0" : "") + leftoverSeconds;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void QuitGame()
    {
        Application.Quit();
    }

}
