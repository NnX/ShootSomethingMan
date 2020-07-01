using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public List<WeaponController> weaponsUnlocked;
    public WeaponController[] totalWeapons;

    [HideInInspector]
    public WeaponController currentWeapon;
    private int _currentWeaponIndex;
    private TypeControlAttack _currentTypeControl;

    private PlayerArmController[] _armController;
    private PlayerAnimations _playerAnim;

    private bool isShooting;

    private void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimations>();

        LoadActiveWeapons();

        _currentWeaponIndex = 1;
    }


    void Start()
    {
        _armController = GetComponentsInChildren<PlayerArmController>();

        ChangeWeapon(weaponsUnlocked[1]);

        _playerAnim.SwitchWeaponAnimation((int)weaponsUnlocked[_currentWeaponIndex].defaultConfig.typeWeapon);
    }

    void LoadActiveWeapons()
    {
        for (int i = 0; i < totalWeapons.Length; i++)
        {
            weaponsUnlocked.Add(totalWeapons[i]);
        }
    }

    public void SwitchWeapon()
    {
        _currentWeaponIndex++;

        _currentWeaponIndex = (_currentWeaponIndex >= weaponsUnlocked.Count) ? 0 : _currentWeaponIndex;

        _playerAnim.SwitchWeaponAnimation((int)weaponsUnlocked[_currentWeaponIndex].defaultConfig.typeWeapon);

        ChangeWeapon(weaponsUnlocked[_currentWeaponIndex]);
    }

    void ChangeWeapon(WeaponController newWeapon)
    {
        if (currentWeapon)
            currentWeapon.gameObject.SetActive(false);

        currentWeapon = newWeapon;
        _currentTypeControl = newWeapon.defaultConfig.typeControl;

        newWeapon.gameObject.SetActive(true);

        if(newWeapon.defaultConfig.typeWeapon == TypeWeapon.Two)
        {
            for (int i = 0; i < _armController.Length; i++)
            {
                _armController[i].ChangeToTwoHand();
            }

        } else
        {
            for (int i = 0; i < _armController.Length; i++)
            {
                _armController[i].ChangeToOneHand();
            }
        }
    }
}
