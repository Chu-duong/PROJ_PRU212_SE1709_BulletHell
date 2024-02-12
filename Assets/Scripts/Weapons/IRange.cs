using UnityEngine;

namespace Weapons
{
    public interface IRange : IWeapon
    {
        public int TotalBullet { get; set; }
        public int BulletPerMag { get; set; }
        public Vector2 Vec { get; set; }
        public float TimeOut { get; set; }
    }
}
