using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLevelIntro : MonoBehaviour {

    LevelManagement lM;

    private void Awake()
    {
        lM = FindObjectOfType<LevelManagement>();
    }
    private void OnEnable()
    {
        EventManager.collectedSwordEvent += SwordCollect;
    }
    private void OnDisable()
    {
        EventManager.collectedSwordEvent -= SwordCollect;
    }
    void SwordCollect()
    {
        lM.EnterEnemies(1);
        lM.SpawnTorch();
        EventManager.collectedSwordEvent -= SwordCollect;
    }
}
