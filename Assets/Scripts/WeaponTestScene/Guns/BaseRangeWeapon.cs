using System;
using UnityEngine;

namespace WeaponTestScene.Guns
{
    public abstract class BaseRangeWeapon : BaseWeapon
    {
        [SerializeField]
        public GameObject Bullet;

        [SerializeField]
        public int BulletPerMag;

        [SerializeField]
        public float ReloadTime;

        [SerializeField]
        public float RecoilTime;
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
            RotateToMousePosition();

            // If user not shoot, then return
            if (timeCheck <= 0)
                return;

            // Else start the recoil count down
            timeCheck -= Time.deltaTime;
            if (timeCheck > 0)
                return;
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

        protected Vector2 GetVectorBaseRotateAngle(float angle)
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return (
                Quaternion.AngleAxis(angle, Vector3.forward)
                * (worldMousePosition - transform.position)
            ).normalized;
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

        // Maybe use for player ?
        private void RotateToMousePosition()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float rotation = mousePosition.x < transform.position.x ? 180f : 0f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.Rotate(xAngle: rotation, yAngle: 0, zAngle: 0f);
        }
    }
}
