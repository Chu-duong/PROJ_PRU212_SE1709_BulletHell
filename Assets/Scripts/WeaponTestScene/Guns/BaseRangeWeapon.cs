using System;
using UnityEngine;

namespace WeaponTestScene.Guns
{
    public abstract class BaseRangeWeapon : BaseWeapon
    {
        [SerializeField] public GameObject Bullet;
        [SerializeField] public int BulletPerMag;
        [SerializeField] public float ReloadTime;
        [SerializeField] public float RecoilTime;
        private float timeCheck;
        protected int checkMag;
        private bool allowShooting;

        private void Start()
        {
            checkMag = BulletPerMag;
            allowShooting = true;
        }

        private void Update()
        {
            // If user not shoot, then return
            if (timeCheck <= 0) return;

            // Else start the recoil count down
            timeCheck -= Time.deltaTime;
            if (timeCheck > 0) return;
            // Recoil check
            if (checkMag > 0)
            {
                allowShooting = true;
            }
            // Out of mag check
            else
            {
                allowShooting = true;
                checkMag = BulletPerMag;
            }
        }

        protected Vector2 GetAngleVector()
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return (worldMousePosition - transform.position).normalized;
        }

        public virtual bool Shoot()
        {
            if (!allowShooting)
                return false;
            --checkMag;
            timeCheck = checkMag > 0 ? RecoilTime : ReloadTime;
            allowShooting = false;
            return true;
        }
    }
}