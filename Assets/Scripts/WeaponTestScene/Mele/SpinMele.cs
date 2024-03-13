using UnityEngine;

public class SpinMele : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(
            0f,
            0f,
            transform.rotation.eulerAngles.z + (speed * Time.deltaTime)
        );
    }
}
