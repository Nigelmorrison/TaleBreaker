using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private Transform spawnPoint;
    public int score;
    [SerializeField] private TMP_Text scoreText;

    public void NewEnemy()
    {
        StartCoroutine(SpawnNow());
    }

    IEnumerator SpawnNow()
    {
        yield return new WaitForSeconds(2f);
        int index = Random.Range(0, Enemy.Length -1);
        GameObject enemyObject = Instantiate(Enemy[index], spawnPoint.position, Quaternion.identity);
        Enemy enemyScript = enemyObject.GetComponent<Enemy>();
        enemyScript.SetSpawner(this);
        
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
