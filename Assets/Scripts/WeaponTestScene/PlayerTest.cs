using System;
using UnityEngine;
using WeaponTestScene;
using WeaponTestScene.Guns;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private BaseRangeWeapon Weapon;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Weapon.Shoot();
        }
    }
}