using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPool : MonoBehaviour
{

    public static SmartPool instance;
    private List<GameObject> bullet_Fall_Fx = new List<GameObject>();
    private List<GameObject> bullet_Prefabs = new List<GameObject>();
    private List<GameObject> bullet_Rocket_Prefabs = new List<GameObject>();
    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }

    public void CreateBulletAndBulletFall(GameObject bullet, GameObject bulletFall, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject temp_Bullet = Instantiate(bullet);
            GameObject temp_Bullet_Fall = Instantiate(bulletFall);

            bullet_Prefabs.Add(temp_Bullet);
            bullet_Fall_Fx.Add(temp_Bullet_Fall);

            bullet_Prefabs[i].SetActive(false);
            bullet_Fall_Fx[i].SetActive(false);
        } 
    }

    public void CreateRocket(GameObject rocket, int count) {
        for (int i = 0; i < count; i++)
        {
            GameObject temp_Rocket_Bullet = Instantiate(rocket);

            bullet_Rocket_Prefabs.Add(temp_Rocket_Bullet);
            bullet_Rocket_Prefabs[i].SetActive(false);
        }
    }

    public GameObject SpawnBulletFallFx(Vector3 position, Quaternion rotation)
    {

        for (int i = 0; i < bullet_Fall_Fx.Count; i++)
        {
            if(!bullet_Fall_Fx[i].activeInHierarchy)
            {
                bullet_Fall_Fx[i].SetActive(true);
                bullet_Fall_Fx[i].transform.position = position;
                bullet_Fall_Fx[i].transform.rotation = rotation;

                return bullet_Fall_Fx[i];
            }
        }
        return null;
    }

    public void SPawnBullet(Vector3 position, Vector3 direction, Quaternion rotation, NameWeapon weaponName)
    {
        if(weaponName != NameWeapon.ROCKET)
        {
            for (int i = 0; i < bullet_Prefabs.Count; i++)
            {
                if(!bullet_Prefabs[i].activeInHierarchy)
                {
                    bullet_Prefabs[i].SetActive(true);
                    bullet_Prefabs[i].transform.position = position;
                    bullet_Prefabs[i].transform.rotation = rotation;

                    break;
                }
            }
        } else
        {
            for (int i = 0; i < bullet_Rocket_Prefabs.Count; i++)
            {
                if (!bullet_Rocket_Prefabs[i].activeInHierarchy)
                {
                    bullet_Rocket_Prefabs[i].SetActive(true);
                    bullet_Rocket_Prefabs[i].transform.position = position;
                    bullet_Rocket_Prefabs[i].transform.rotation = rotation;



                    break;
                }
            } 
        }
    }
}
