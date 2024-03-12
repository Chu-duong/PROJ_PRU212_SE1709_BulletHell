using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

public class M4A1 : BaseRangeWeapon
{
    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;
        Instantiate(Bullet, transform.position, Bullet.transform.rotation)
            .GetComponent<BaseBullet>()
            .Direction = GetVectorBaseRotateAngle(0);
        return true;
    }
}
