using UnityEngine;
using UnityEngine.Events;

namespace WeaponTestScene.Bullets
{
    public abstract class BaseBullet : MonoBehaviour
    {
        public Vector2 Direction;

        [SerializeField]
        public float TimeOut;

        [SerializeField]
        public float Speed;

        public int Damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("Terrain"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
