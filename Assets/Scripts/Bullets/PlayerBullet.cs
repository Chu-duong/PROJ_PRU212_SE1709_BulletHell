using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField]
        private float BulletSpeed;

        [SerializeField]
        private float TimeOut;

        private Rigidbody2D rb;
        public Vector2 vec;
        private float _timeout;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            rb.velocity = vec * BulletSpeed;
            _timeout += Time.deltaTime;
            if (_timeout >= TimeOut)
            {
                gameObject.SetActive(false);
                _timeout = 0;
            }
        }

        Vector2 GetShootAngle()
        {
            float angle = (transform.rotation.z + 90) * Mathf.PI / 180f;
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy")) { }
            if (collision.gameObject.CompareTag("Terrain"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
