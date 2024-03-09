using UnityEngine;
using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

namespace WeaponTestScene
{
    public class Pistol : BaseRangeWeapon
    {
        public override bool Shoot()
        {
            if (!base.Shoot()) return false;
            Instantiate(Bullet, transform.position, Bullet.transform.rotation).GetComponent<BaseBullet>().Direction =
                GetAngleVector();
            return true;
        }
    }
}