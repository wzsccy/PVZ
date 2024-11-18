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
    //���ɽ�ʬ
    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }
    IEnumerator SpawnZombie()
    {
        //��һ�� 5
        for (int i = 0; i < 5; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(3);
        //�ڶ��� 10
        for (int i = 0; i < 10; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(3);
        //������ 10
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
