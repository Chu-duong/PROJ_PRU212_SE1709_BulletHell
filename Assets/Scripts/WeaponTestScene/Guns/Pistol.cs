using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

namespace WeaponTestScene
{
    public class Pistol : BaseRangeWeapon
    {
        public override bool Shoot()
        {
            if (!base.Shoot())
                return false;
            foreach (var bullet in BulletController.ListNineMMBullets)
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
}
