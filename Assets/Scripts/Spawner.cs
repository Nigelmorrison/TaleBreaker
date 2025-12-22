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
        Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
    }
}
