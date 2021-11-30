using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public Vector3[] hazardSpawnPoints;
    Vector3[] globalSpawnPoint;

    [SerializeField] GameObject hazardToSpawn;

    int currentDropHazardPoint;

    [SerializeField] float minTimeBetweenFalls = 0.5f;
    [SerializeField] float maxTimeBetweenFalls = 1.5f;

    float timeBetweenFalls;

    [SerializeField] float activeTime = 10;

    bool spawnReady = false;
    bool active;

    void Start()
    {
        globalSpawnPoint = new Vector3[hazardSpawnPoints.Length];
        for (int i = 0; i < hazardSpawnPoints.Length; i++)
        {
            globalSpawnPoint[i] = hazardSpawnPoints[i] + transform.position;
        }

        currentDropHazardPoint = Random.Range(0, hazardSpawnPoints.Length);
        timeBetweenFalls = Random.Range(minTimeBetweenFalls, maxTimeBetweenFalls);
    }

    void Update()
    {
        if (active)
        {
            if (spawnReady)
            {
                StartCoroutine(FallDelay());
                spawnReady = false;
                GameObject spawnedObject = Instantiate(hazardToSpawn, globalSpawnPoint[currentDropHazardPoint], transform.rotation);
                spawnedObject.GetComponent<FallingObject>().TriggerFall();
            }
        }
    }

    public void TriggerFall()
    {
        active = true;
        spawnReady = true;

        if (activeTime > 0)
        {
            StartCoroutine(ActiveTime());
        }
    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(timeBetweenFalls);
        currentDropHazardPoint = Random.Range(0, hazardSpawnPoints.Length);
        timeBetweenFalls = Random.Range(minTimeBetweenFalls, maxTimeBetweenFalls);
        spawnReady = true;
    }

    IEnumerator ActiveTime()
    {
        yield return new WaitForSeconds(activeTime);
        active = false;
    }

    private void OnDrawGizmos()
    {
        if (hazardSpawnPoints != null)
        {
            Gizmos.color = Color.red;
            float size = 0.3f;

            for (int i = 0; i < hazardSpawnPoints.Length; i++)
            {
                Vector3 spawnPoint = hazardSpawnPoints[i] + transform.position;

                Gizmos.DrawLine(spawnPoint - Vector3.up * size, spawnPoint + Vector3.up * size);
                Gizmos.DrawLine(spawnPoint - Vector3.left * size, spawnPoint + Vector3.left * size);
            }


        }


    }
}
