using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour {

    AudioSource aS;
    Image camFaderImage;

    private void Awake()
    {
        aS = GetComponent<AudioSource>();

    }
    private void Start()
    {
        camFaderImage = GameObject.Find("Canvas").transform.Find("Image").GetComponent<Image>();
        StartCoroutine(Fadesong());
        StartCoroutine(StartFade());
    }
    IEnumerator StartFade()
    {
        Color c = camFaderImage.color;
        while (c.a <= 254)
        {
            c.a += 0.001f;
            camFaderImage.color = c;
            yield return new WaitForSeconds(0.01f);
        }

      

    }
    IEnumerator Fadesong()
    {
        while(aS.volume >= 0.1f)
        {
            aS.volume -= 0.01f;
            
            yield return new WaitForSeconds(0.15f);
        }
        if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No more levels");
        }
    }
}
