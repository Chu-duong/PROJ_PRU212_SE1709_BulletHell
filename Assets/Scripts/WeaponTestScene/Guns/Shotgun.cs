using UnityEngine;
using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

public class Shotgun : BaseRangeWeapon
{
    const float DIFF = 20f;

    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;
        var position = transform.position;
        var rotation = Bullet.transform.rotation;
        Instantiate(Bullet, position, rotation).GetComponent<BaseBullet>().Direction =
            GetVectorBaseRotateAngle(0f);
        Instantiate(Bullet, position, rotation).GetComponent<BaseBullet>().Direction =
            GetVectorBaseRotateAngle(DIFF);
        Instantiate(Bullet, position, rotation).GetComponent<BaseBullet>().Direction =
            GetVectorBaseRotateAngle(-DIFF);
        return true;
    }
}
