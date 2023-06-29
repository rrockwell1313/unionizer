using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    public Component clickedButton;

    //define source
    [SerializeField] private AudioSource _effectsSource;

    [SerializeField] public AudioClip ButtonClickSFX;
    [SerializeField] public AudioClip MapOpenSFX;
    [SerializeField] public AudioClip InteractOpenSFX;
    [SerializeField] public AudioClip InteractCloseSFX;
    [SerializeField] public AudioClip QuestWinSFX;
    [SerializeField] public AudioClip QuestLoseSFX;
    [SerializeField] public AudioClip RepUpSFX;
    [SerializeField] public AudioClip RepDownSFX;

    //intend to have these be randomized of a few selections
    [SerializeField] public AudioClip HmmSFX;
    [SerializeField] public AudioClip IdleActionSFX;
    [SerializeField] public AudioClip AngryVoiceSFX;
    [SerializeField] public AudioClip ContentVoiceSFX;

    public Canvas Canvas;

    //add public SoundManager soundManager; to script, soundManager.PlaySound(AudioClip 'clip');

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
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

}
