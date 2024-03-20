using UnityEngine;
using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

public class M4A1 : BaseRangeWeapon
{
    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;
        foreach (var bullet in BulletController.ListFiveDotSixTwoBullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.GetComponent<BaseBullet>().Direction = GetVectorBaseRotateAngle(0);
                bullet.GetComponent<BaseBullet>().Damage = damage;
                bullet.SetActive(true);
                break;
            }
        }
        return true;
    }
}
