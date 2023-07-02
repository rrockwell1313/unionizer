using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    bool changingScenes = false;
    float opacity = 300f;
    [SerializeField] private Image BlackFadeImage;
    bool IntroFinished = false;
    [SerializeField] private GameObject StampImage;
    [SerializeField] private Text pressStart;
    private float startScale = 1.0f;
    private float scaleSet = 3.0f;

    private void Start()
    {
        StampImage.transform.localScale = new Vector3(3f, 3f, 3f);
        InvokeRepeating("StampImageIn", 5, .01f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!IntroFinished)
        {
            FadeOutImage();
            StampImageIn();
        }
        if(Input.anyKeyDown && !changingScenes && IntroFinished)
        {
            changingScenes = true;
        }
        if(changingScenes && opacity < 300)
        {
            FadeToBlack();
        }
    }
    void FadeOutImage()
    {
        if (opacity > 0)
        {
            opacity--;
            BlackFadeImage.color = new Color(BlackFadeImage.color.r, BlackFadeImage.color.g, BlackFadeImage.color.b, opacity / 300); //increase opacity of canvas image
        }
    }
    void StampImageIn()
    {
        if (scaleSet > startScale)
        {
            scaleSet = scaleSet - .01f;
            StampImage.transform.localScale = new Vector3(scaleSet, scaleSet, scaleSet);
        }
        if (scaleSet <= startScale)
        {
            CancelInvoke();
            IntroFinished = true;
            pressStart.enabled = true;
        }
    }
    void FadeToBlack()
    {
        opacity++;
        BlackFadeImage.color = new Color(BlackFadeImage.color.r, BlackFadeImage.color.g, BlackFadeImage.color.b, opacity / 300); //increase opacity of canvas image
        if (opacity >= 300)
        {
            //switch to scene "MyDevOffice"
            SceneManager.LoadScene(1);
        }
    }
}
