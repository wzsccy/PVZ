using System.Collections;
using UnityEngine;

enum SpawnState
{
    NotStart,
    Spawning,
    End
}
public class ZombieManager : MonoBehaviour
{
    public static ZombieManager instance { get; private set; }

    private SpawnState spawnState=SpawnState.NotStart;

    public Transform[] spawnPointList;
    public GameObject zombiePrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartSpawn();
    }
    //生成僵尸
    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }
    IEnumerator SpawnZombie()
    {
        //第一波 5
        for (int i = 0; i < 5; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(3);
        //第二波 10
        for (int i = 0; i < 10; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(3);
        //第三波 10
        for (int i = 0; i < 10; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(3);
        }
        
    }
    private void SpawnARandomZombie()
    {
        int index=Random.Range(0, spawnPointList.Length);
        GameObject.Instantiate(zombiePrefab,spawnPointList[index].position,Quaternion.identity);
    }
}
