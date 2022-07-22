using System.Collections;
using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region Singleton class : GameManager
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    void RemoveBridge()
    {

    }

    void EngineStart()
    {

    }

    void IncreaseEnginePower()
    {

    }

    void DisconnectStage1()
    {

    }

    void DisconnectFairing()
    {

    }

    void DisconnectStage2()
    {

    }

    void SwitchingLandingLegs()
    {

    }
}

