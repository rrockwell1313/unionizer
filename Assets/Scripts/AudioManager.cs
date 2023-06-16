using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AudioManager : MonoBehaviour
{

    public AudioClip[] musicClips;
    public int currentClipIndex = 0;

    private AudioSource audioSource;

    public TextMeshProUGUI nowPlayingText;
    public TextMeshProUGUI musicTimerText;

    // Singleton instance
    public static AudioManager Instance;

    public GameObject playButton;
    public GameObject pauseButton;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This prevents the object from being destroyed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (currentClipIndex >= 0 && currentClipIndex < musicClips.Length)
        {
            PlayMusic(currentClipIndex);
        }
        else
        {
            Debug.Log("Your music is bad and you should feel bad");
        }
    }


    public void PlayMusic(int index)
    {
        // Validate the index
        if (index >= 0 && index < musicClips.Length)
        {
            audioSource.clip = musicClips[index];
            audioSource.Play();
            nowPlayingText.text = "Now Playing - " + musicClips[index].name;

        }
        else
        {
            Debug.LogWarning("Invalid music index! Please set a valid index.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
        {
            // Calculate the remaining time and format it as MM:SS
            int remainingSeconds = (int)(audioSource.clip.length - audioSource.time);
            string minutes = (remainingSeconds / 60).ToString("00");
            string seconds = (remainingSeconds % 60).ToString("00");
            musicTimerText.text = minutes + ":" + seconds;
        }
        else
        {
            // If the current song is finished, play the next song
            currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
            PlayMusic(currentClipIndex);
        }
    }

    public void NextSong()
    {
        currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
        PlayMusic(currentClipIndex);
    }

    public void PreviousSong()
    {
        currentClipIndex--;
        if (currentClipIndex < 0)
        {
            currentClipIndex = musicClips.Length - 1;
        }
        PlayMusic(currentClipIndex);
    }

    public void TogglePausePlay()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            playButton.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            audioSource.Play();
            playButton.SetActive(false);
            pauseButton.SetActive(true);
        }
    }
}
