using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageStartMenu : MonoBehaviour {

    public float maxMusicVolume;
    public float maxSquealVolume;
    public AudioSource music;
    public AudioSource squeal;
    public Button startButton;
    public Slider volumeSlider;
    public GameObject player;
    public GameObject spawner;
    public GameObject seatTracker;
    public GameObject timeTracker;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);

        Slider slider = volumeSlider.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { AdjustVolume(slider.value); });
    }

    void StartGame()
    {
        player.SetActive(true);
        spawner.SetActive(true);
        seatTracker.SetActive(true);
        timeTracker.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void AdjustVolume(float volume)
    {
        music.volume = volume * maxMusicVolume;
        squeal.volume = volume * maxSquealVolume;
    }

}
