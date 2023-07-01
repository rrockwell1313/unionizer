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
    [SerializeField] private Image StampImage;


    private void Awake()
    {
        StampImageIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IntroFinished)
        {
            FadeOutImage();
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
        opacity--;
        Debug.Log("opacity = " + opacity);
        BlackFadeImage.color = new Color(BlackFadeImage.color.r, BlackFadeImage.color.g, BlackFadeImage.color.b, opacity / 300); //increase opacity of canvas image
        if (opacity <= 0)
        {
            IntroFinished = true;
        }
    }
    void StampImageIn()
    {
        Debug.Log("Bring the Stamp Image In");
    }
    void FadeToBlack()
    {
        opacity++;
        Debug.Log("opacity = " + opacity);
        BlackFadeImage.color = new Color(BlackFadeImage.color.r, BlackFadeImage.color.g, BlackFadeImage.color.b, opacity / 300); //increase opacity of canvas image
        if (opacity >= 300)
        {
            //switch to scene "MyDevOffice"
            SceneManager.LoadScene(1);
        }
    }
}
