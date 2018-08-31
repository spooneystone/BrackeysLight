using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource[] aS;

    public AudioClip[] sounds;

    private void OnEnable()
    {
        EventManager.SoundPlayEvent += SetAndPlaysound;
        EventManager.SoundForDoorPlayEvent += SetAndPlayDoorsound;
    }
    private void OnDisable()
    {
        EventManager.SoundPlayEvent -= SetAndPlaysound;
        EventManager.SoundForDoorPlayEvent -= SetAndPlayDoorsound;
    }
    private void Awake()
    {
        aS = GetComponents<AudioSource>();
        Debug.Log(aS.Length);
    }

    public void SetAndPlaysound(int value)
    {
        
            aS[0].clip = sounds[value];
            aS[0].Play();
        
      
        
    }
    public void SetAndPlayDoorsound(int value)
    {
        
            aS[1].clip = sounds[value];
            aS[1].Play();
        

    }
}
