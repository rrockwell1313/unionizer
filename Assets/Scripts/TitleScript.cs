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
    private Vector3 startScale;
    private float xScale = 1.0f;
    private float yScale = 1.0f;
    private float zScale = 1.0f;
    private float scaleSet = 3.0f;

    private void Start()
    {
        startScale = StampImage.transform.localScale;
        StampImage.transform.localScale = new Vector3(3f, 3f, 3f);
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

        StampImage.transform.localScale = new Vector3(3f, 3f, 3f);
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
