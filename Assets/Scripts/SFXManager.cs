using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //TO ACCESS THE SOUNDS FROM THIS SCRIPT, ADD THE FOLLOWING SFXManager.Instance.PlaySound("YourSoundName"); to the script you want to play the sound.
    public static SFXManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public List<Sound> sounds;

    public Dictionary<string, AudioClip> soundDictionary;

    //define source
    private AudioSource _effectsSource;

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

        //initialize the dictionary
        soundDictionary = new Dictionary<string, AudioClip>();   
        foreach (var sound in sounds)
        {
            soundDictionary.Add(sound.name, sound.clip);
        }

        _effectsSource = GetComponent<AudioSource>();
        if (_effectsSource == null)
        {
            _effectsSource = gameObject.AddComponent<AudioSource>();
        }
    }
    public void PlaySound(string soundName)
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            _effectsSource.PlayOneShot(soundDictionary[soundName]);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
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
