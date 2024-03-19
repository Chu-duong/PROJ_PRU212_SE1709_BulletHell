using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeaponTestScene.Guns;

public class bulletCount : MonoBehaviour
{
    public Text bulletText;
    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text=BaseRangeWeapon.GetAmo().ToString();
    }
}
