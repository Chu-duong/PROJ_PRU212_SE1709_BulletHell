using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject FiveDotSixTwoBullet;

    [SerializeField]
    private GameObject NineMMBullet;

    [SerializeField]
    private GameObject TwelveMMBullet;

    [SerializeField]
    private int FiveDotSixTwoBulletAmo;

    [SerializeField]
    private int NineMMBulletAmo;

    [SerializeField]
    private int TwelveMMBulletAmo;

    public static List<GameObject> ListFiveDotSixTwoBullets = new();
    public static List<GameObject> ListNineMMBullets = new();
    public static List<GameObject> ListTwelveMMBullets = new();

    // Start is called before the first frame update
    void Start()
    {
        SpawnBullet(FiveDotSixTwoBullet, FiveDotSixTwoBulletAmo, ref ListFiveDotSixTwoBullets);
        SpawnBullet(NineMMBullet, NineMMBulletAmo, ref ListNineMMBullets);
        SpawnBullet(TwelveMMBullet, TwelveMMBulletAmo, ref ListTwelveMMBullets);
    }

    private void SpawnBullet(GameObject bullet, int amo, ref List<GameObject> list)
    {
        GameObject bulletGameObject;
        for (int i = 0; i < amo; i++)
        {
            bulletGameObject = Instantiate(bullet);
            bulletGameObject.SetActive(false);
            list.Add(bulletGameObject);
        }
    }

    void OnDestroy()
    {
        ListFiveDotSixTwoBullets.Clear();
        ListNineMMBullets.Clear();
        ListTwelveMMBullets.Clear();
    }
}
