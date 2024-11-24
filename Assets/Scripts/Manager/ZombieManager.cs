using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
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

    private SpawnState spawnState = SpawnState.NotStart;

    public Transform[] spawnPointList;
    public GameObject zombiePrefab;
    [SerializeField]
    private List<Zombie> zombieList = new List<Zombie>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //StartSpawn();
    }
    public void Pause()
    {
        spawnState = SpawnState.End;
        foreach (Zombie zombie in zombieList)
        {
            zombie.TranstionToPause();
        }
    }

    private void Update()
    {
            if(spawnState == SpawnState.End && zombieList.Count == 0)
        {
            GameManager.instance.GameEndSuccess();
        }
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
        AudioManager.Instance.PlayClip(Config.lastwave);
        //第三波 10
        for (int i = 0; i < 10; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(3);
        }
        spawnState = SpawnState.End;
    }
    private void SpawnARandomZombie()
    {
        if (spawnState == SpawnState.Spawning)
        {
            int index = Random.Range(0, spawnPointList.Length);
            GameObject go = GameObject.Instantiate(zombiePrefab, spawnPointList[index].position, Quaternion.identity);
            zombieList.Add(go.GetComponent<Zombie>());
            go.GetComponent<SpriteRenderer>().sortingOrder = spawnPointList[index].GetComponent<SpriteRenderer>().sortingOrder;
        }
    }
    public void RemoveZombie(Zombie zombie)
    {
        zombieList.Remove(zombie);
    }
}
