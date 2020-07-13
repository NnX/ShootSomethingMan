using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{

    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem fx_shot;
    public GameObject fx_bulletFall;
    private Collider2D fireCollider;
    private WaitForSeconds wait_time = new WaitForSeconds(0.02f);
    private WaitForSeconds fire_ColliderWait = new WaitForSeconds(0.02f);

    void Start()
    {

        if(!GameplayController.instance.bullet_And_BulletFX_Created)
        {
            GameplayController.instance.bullet_And_BulletFX_Created = true;
            if (nameWp != NameWeapon.FIRE && nameWp != NameWeapon.ROCKET)
            {
                SmartPool.instance.CreateBulletAndBulletFall(bulletPrefab, fx_bulletFall, 100);
            }
        }

        if (!GameplayController.instance.rocket_Bullet_Created)
        {
            if(nameWp == NameWeapon.ROCKET)
            {
                GameplayController.instance.rocket_Bullet_Created = true;
                SmartPool.instance.CreateRocket(bulletPrefab, 100);
            }
        }
    }

    public override void ProcessAttack()
    {
        //base.ProcessAttack();

        switch(nameWp)
        {
            case NameWeapon.PISTOL:
                break;
            case NameWeapon.MP5:
                break;
            case NameWeapon.M3:
                break;
            case NameWeapon.AK:
                break;
            case NameWeapon.AWP:
                break;
            case NameWeapon.FIRE:
                break;
            case NameWeapon.ROCKET:
                break;
            default:
                print("Weapon type not found");
                break;
        }

        if((transform != null) && (nameWp != NameWeapon.FIRE))
        {
            if(nameWp != NameWeapon.ROCKET)
            {
                GameObject bullet_Fall_FX = SmartPool.instance.SpawnBulletFallFx(spawnPoint.transform.position, Quaternion.identity);
                bullet_Fall_FX.transform.localScale = (transform.root.eulerAngles.y > 1.0f) ? new Vector3(-1f,1f,1f) : new Vector3(1f,1f,1f);

                StartCoroutine(WaitForShootEffect());
            }

            SmartPool.instance.SPawnBullet(spawnPoint.transform.position, new Vector3(-transform.root.localScale.x, 0f, 0f), spawnPoint.rotation, nameWp);
        } else
        {
            StartCoroutine(ActiveFireCollider());
        }
    } // process attack

    IEnumerator WaitForShootEffect()
    {
        yield return wait_time;
        fx_shot.Play();
    }


    IEnumerator ActiveFireCollider()
    {

        fx_shot.Play();
        //fireCollider.enabled = true;

        yield return fire_ColliderWait;

        //fireCollider.enabled = false;
    }


} // class
