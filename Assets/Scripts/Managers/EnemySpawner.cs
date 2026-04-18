using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Level Reference")]
    public LevelGenerator levelData;

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
        
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        EnemyMovement enemyScript = newEnemy.GetComponent<EnemyMovement>();
        if (enemyScript != null)
        {
            enemyScript.currentLane = randomLane;
            enemyScript.levelData = this.levelData; 
        }

        // Return the newly created enemy
        return newEnemy;
    }
}
