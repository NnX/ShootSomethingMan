using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public bool bullet_And_BulletFX_Created, rocket_Bullet_Created;

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
        MakeInstance();
    }
    private void OnDestroy()
    {
        instance = null;
    }



}
