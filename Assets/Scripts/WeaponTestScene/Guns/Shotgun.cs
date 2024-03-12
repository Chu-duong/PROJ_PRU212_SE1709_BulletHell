using System.Collections.Generic;
using UnityEngine;
using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

public class Shotgun : BaseRangeWeapon
{
    const float DIFF = 20f;
    const int bulletPerShot = 3;

    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;

        List<GameObject> bullets = new();

        for (int i = 0; i < BulletController.ListTwelveMMBullets.Count; i++)
        {
            if (!BulletController.ListTwelveMMBullets[i].activeInHierarchy)
            {
                bullets.Add(BulletController.ListTwelveMMBullets[i]);
            }
            if (bullets.Count == bulletPerShot)
            {
                break;
            }
        }
        Setup(bullets[0], 0);
        for (int i = 1; i < bullets.Count; i++)
        {
            if (i % 2 != 0)
            {
                Setup(bullets[i], DIFF);
            }
            else
            {
                Setup(bullets[i], -DIFF);
            }
        }
        return true;
    }

    private void Setup(GameObject bullet, float angle)
    {
        var position = transform.position;
        var rotation = Bullet.transform.rotation;
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.GetComponent<BaseBullet>().Direction = GetVectorBaseRotateAngle(angle);
        bullet.SetActive(true);
    }
}
