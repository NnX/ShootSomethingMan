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

        ///SPAWN Bullet
    } // process attack

    IEnumerator WaitForShootEffect()
    {
        yield return wait_time;
        fx_shot.Play();
    }


    IEnumerator ActiveFireCollider()
    {
        fireCollider.enabled = true;

        yield return fire_ColliderWait;

        fireCollider.enabled = false;
    }


} // class
