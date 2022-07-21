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

    //public SecondStep secondStep;
    //public byte length;
    //public byte width;
    //public FirstStage firstStage;
    //public byte maximumAmountFuel;
    //public byte rightAmountFuel;


    //public void Start()
    //{
    //    this.secondStep.length = length;
    //    this.secondStep.width = width;
    //    this.firstStage.maximumAmountFuel = maximumAmountFuel;
    //    this.firstStage.rightAmountFuel = rightAmountFuel;
    //}

    //public void ButtonDetachment()
    //{

    //    secondStep.Detachment();
    //}

    //public void ButtonTankAndLaunch()
    //{
    //    firstStage.TankFilling();
    //}

    //public void ButtonRocketLaunch()
    //{


    //}
}

