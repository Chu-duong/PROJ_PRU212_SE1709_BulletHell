using UnityEngine;
using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

public class Shotgun : BaseRangeWeapon
{
    const float DIFF = 0.5f;

    public override bool Shoot()
    {
        if (!base.Shoot()) return false;
        var position = transform.position;
        var rotation = Bullet.transform.rotation;
        var userDirection = GetAngleVector();
        Instantiate(Bullet, position, rotation)
            .GetComponent<BaseBullet>().Direction = userDirection;
        Instantiate(Bullet, position, rotation)
            .GetComponent<BaseBullet>().Direction = userDirection + new Vector2(0, DIFF);
        Instantiate(Bullet, position, rotation)
            .GetComponent<BaseBullet>().Direction = userDirection - new Vector2(0, DIFF);
        return true;
    }
}