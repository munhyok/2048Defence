using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform  canvasTransform;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private Transform[] wayPoints;
    private List<Enemy> enemyList;

    public List<Enemy> EnemyList => enemyList;
    public static int enemyCount = 0;

    private void update(){
        
    }
    private void Awake()
    {
        enemyList = new List<Enemy>();
        enemyCount = 0;
        StartCoroutine("SpawnEnemy");
        

    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();
            enemyCount ++;
            

            enemy.Setup(this, wayPoints);
            enemyList.Add(enemy);

            SpawnEnemyHPSlider(clone);

            yield return new WaitForSeconds(spawnTime);
            //Debug.Log(enemyCount+1);
            
        }
        
    }

    public void DestroyEnemy (Enemy enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
        enemyCount --;
        Debug.Log(enemyCount);
        
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
        
    }
}
