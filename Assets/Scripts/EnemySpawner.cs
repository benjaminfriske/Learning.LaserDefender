using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    private int waveIndex = 0;

    private void Start()
    {
        var currentWave = waveConfigs[waveIndex];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (var x = 0; x < waveConfig.GetNumberOfEnemies(); x++)
        {
            Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

        if (waveIndex < (waveConfigs.Count - 1))
        {
            waveIndex++;
            StartCoroutine(SpawnAllEnemiesInWave(waveConfigs[waveIndex]));
        }
    }
}
