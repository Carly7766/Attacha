using System.Collections;
using System.Collections.Generic;
using Attacha.Scripts.Manager;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool DontDestroyOnLoad => true;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("test");
    }
}