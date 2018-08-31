using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    Image camFaderImage;

    private void Awake()
    {
        camFaderImage = GameObject.Find("ViewCanvas").transform.Find("CameraFade").GetComponent<Image>();
        Color t = camFaderImage.color;
        t.a = 1f;
        camFaderImage.color = t;
    }
    private void Start()
    {
        
       
        StartCoroutine(StartFade());
    }
    IEnumerator StartFade()
    {
        Color c = camFaderImage.color;
        while (c.a > 0)
        {
            c.a -= 0.005f;
            camFaderImage.color = c;
            yield return new WaitForSeconds(0.01f);
        }
        
        
    }

   
}
