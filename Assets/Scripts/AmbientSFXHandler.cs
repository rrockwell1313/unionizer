using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSFXHandler : MonoBehaviour
{
    public static AmbientSFXHandler Instance;
    //set a timer between 8 seconds and 15 seconds and then play one of the ambient sounds
    int timer = 0;
    int randTimer = 0;
    [SerializeField] int timerMin = 0;
    [SerializeField] int timerMax = 0;
    int randSFX = 0;
    [SerializeField] int sfxMin = 0;
    [SerializeField] int sfxMax = 0;
    string ambSoundName = "TypingAmbience";
    [SerializeField] List<string> soundList = new List<string>();
    private AudioSource soundSource;

    //singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (soundSource == null)
        {
            soundSource = GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + ambSoundName);
            return;
        }
    }

    private void Start()
    {   
        ResetSfxTime();
    }

    void TimeDown()
    {
        timer--;
        if (timer == 0)
        {
            CancelInvoke();
            soundSource.PlayOneShot(SFXManager.Instance.soundDictionary[ambSoundName]);
            Debug.Log("Played" + ambSoundName + "after" + randTimer + "seconds");
            ResetSfxTime();
        }

    }


    void ResetSfxTime()
    {
        randTimer = Random.Range(timerMin, timerMax); //set a random time between max and min before sfx will play
        randSFX = Random.Range(sfxMin, sfxMax); //decide on a random sfx to play
        ambSoundName = soundList[randSFX]; //gets the index of randSfx from list
        timer = randTimer; //sets timer value to the random time before beginning subtraction
        InvokeRepeating("TimeDown", 1, 1);

    }
}
