using UnityEngine;

namespace WeaponTestScene
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField]
        protected int damage;
    }
}
