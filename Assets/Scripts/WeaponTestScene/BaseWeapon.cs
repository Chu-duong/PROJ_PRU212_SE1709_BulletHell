using UnityEngine;

namespace WeaponTestScene
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip shootingSound;
        [SerializeField]
        protected int damage;
    }
}
