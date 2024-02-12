using UnityEngine;

namespace Weapons
{
    public class EnemyBullet : MonoBehaviour
    {
        private float _damage;

        // Start is called before the first frame update
        void Start() { }

        // Update is called once per frame
        void Update() { }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Player.MinusHealth?.Invoke(_damage);
            }
            gameObject.SetActive(false);
        }
    }
}
