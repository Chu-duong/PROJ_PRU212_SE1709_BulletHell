using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private float MinimumSpawnTime;

    [SerializeField]    
    private float MaximumSpawnTime;

    private float TimeUntilSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilSpawn = TimeUntilSpawn - Time.deltaTime;
        if (TimeUntilSpawn < 0)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        TimeUntilSpawn = Random.Range(MinimumSpawnTime, MaximumSpawnTime);
    }

}
