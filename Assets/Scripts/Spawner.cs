using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform spawnPoint;
    public void NewEnemy()
    {
        StartCoroutine(SpawnNow());
    }

    IEnumerator SpawnNow()
    {
        yield return new WaitForSeconds(2f);
        GameObject enemyObject = Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
        Enemy enemyScript = enemyObject.GetComponent<Enemy>();
        enemyScript.SetSpawner(this);
    }
}
