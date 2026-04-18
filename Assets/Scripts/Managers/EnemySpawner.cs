using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Level Reference")]
    public LevelGenerator levelData;

    [Header("Enemy Pool")]
    [SerializeField] private GameObject[] enemyPool;

    void Start()
    {
        if (levelData == null) 
        {
            levelData = Object.FindFirstObjectByType<LevelGenerator>();
        }
    }

    // Changed from void to GameObje0ct
    //NEW - Made enemyPrefab an optional parameter
    public GameObject SpawnEnemy(GameObject enemyPrefab = null)
    {
        //OLD
        //if (levelData == null || enemyPrefab == null) return null;
        //NEW
        if (enemyPrefab == null) return null;

        int randomLane = Random.Range(0, levelData.polygonSides);
        Vector3 spawnPos = new Vector3(0, 0, levelData.tubeLength);

        //OLD
        // GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        //NEW
        GameObject newEnemy = null;
        for(int i = 0; i < enemyPool.Length; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                newEnemy = enemyPool[i];
                newEnemy.transform.position = spawnPos;
                newEnemy.SetActive(true);
                break;
            }
        }

        if(newEnemy == null)
        {
            return null;
        }

        EnemyMovement enemyScript = newEnemy.GetComponent<EnemyMovement>();
        if (enemyScript != null)
        {
            enemyScript.currentLane = randomLane;
            enemyScript.levelData = this.levelData;
            enemyScript.RestartBehavior();
        }

        // Return the newly created enemy
        return newEnemy;
    }
}
