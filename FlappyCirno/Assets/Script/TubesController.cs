using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubesController : MonoBehaviour
{
    [SerializeField] private float lifeTime = 4;
    [SerializeField] private float spawnDelay = 1;
    [SerializeField] private Vector2 spawnPosittion = new Vector2(5f, 0.5f);

    private IPool pool;
    private void Awake()
    {
        pool = GetComponent<IPool>();
    }
    void Start()
    {
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnTube());
        StartCoroutine(Spawner());
    }
    private IEnumerator SpawnTube()
    {
        GameObject item = pool.item;
        item.transform.position = spawnPosittion;
        item.SetActive(true);
        yield return new WaitForSeconds(lifeTime);
        pool.item = item;
    }
}
