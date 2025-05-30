using UnityEngine;
using System.Collections;
using TMPro;

public class wavespawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public TMP_Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    public float countdown = 10f;

    private int waveNumber = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        
    }
    
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
