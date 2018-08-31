using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour {

    public static Action<int> SoundPlayEvent;
    public static Action<int> SoundForDoorPlayEvent;
    public static Action collectedSwordEvent;
    public static Action LevelEnded;
    public static Action PlayerDead;

}
