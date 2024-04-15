using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] private GameObject multiplierPrefab;
    [SerializeField] private Transform multiplierParent;

    [SerializeField] private Transform spawnOriginMultiplier;

    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnOffset;
    [SerializeField] private float multiplierSpeed;

    [SerializeField] private float leftmostEdge;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;

        SpawnMultiplier();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawnMultiplier())
        {
            Debug.Log("timer ended. please spawn a multiplier");
            SpawnMultiplier();
        }

        //MoveMultiplier();
        DestroyMultiplier();
    }
    
    private bool ShouldSpawnMultiplier()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = spawnInterval;
            return true;
        }

        return false;
    }

    private void SpawnMultiplier()
    {
        Vector2 randPos = spawnOriginMultiplier.position + new Vector3(0, Random.Range(-spawnOffset, spawnOffset), 0);

        Instantiate(multiplierPrefab, randPos, spawnOriginMultiplier.rotation, multiplierParent);
    }

    

    private void DestroyMultiplier()
    {
        foreach (Transform pointMultiplier in multiplierParent)
        {
            if (pointMultiplier.position.x <= leftmostEdge)
            {
                Destroy(pointMultiplier.gameObject);
            }
        }
    }

}
