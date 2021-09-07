using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TubesController : MonoBehaviour, IItemSpawner
{
    private float lifeTime;
    private float spawnDelay;
    private Vector2 spawnPosittion;
    private int poolSizeTube;
    private float randomRange;
    private Settings settings;
    private float speed;
    private GameObject tube;
    private IPool pool;
    private int poolIndex;
    private readonly List<Rigidbody2D> pipes = new List<Rigidbody2D>();
    private bool _pause = false;
    public bool pause
    {
        get { return _pause; }
        set
        {
            _pause = value;
            Vector2 newVelocity = Vector2.zero;
            if (!value)
            {
                newVelocity.x = -speed;
            }
            for (int i = 0; i < pipes.Count; i++)
            {
                pipes[i].velocity = newVelocity;
            }
        }
    }
    [Inject]
    private void Construct(IPool pool, Settings settings)
    {
        this.pool = pool;
        this.settings = settings;
        lifeTime = settings.tubeLifeTime;
        spawnDelay = settings.tubeSpawnDelay;
        spawnPosittion = settings.tubeSpawnPosition;
        poolSizeTube = settings.tubePoolSize;
        randomRange = settings.tubeJumpRange;
    }
    private IEnumerator Spawner()
    {
        float localTime = spawnDelay;
        while (localTime > 0f)
        {
            yield return new WaitForEndOfFrame();
            if (!pause)
                localTime -= Time.deltaTime;
        }
        StartCoroutine(SpawnTube());
        StartCoroutine(Spawner());
    }
    private IEnumerator SpawnTube()
    {
        GameObject item = pool.GetItem(poolIndex);
        Rigidbody2D itemBody = item.GetComponent<Rigidbody2D>();
        pipes.Add(itemBody);
        item.SetActive(true);
        itemBody.position = spawnPosittion + new Vector2 (0, Random.Range(-randomRange, randomRange));
        itemBody.velocity = new Vector2(-speed, 0f);
        float localTime = lifeTime;
        while (localTime > 0f)
        {
            yield return new WaitForFixedUpdate();
            if (!pause)
                localTime -= Time.fixedDeltaTime;
        }
        pool.ReturnItem(item, poolIndex);
    }
    public void StartSpawn(GameObject item, float speed)
    {
        this.speed = speed;
        tube = item;
        poolIndex = pool.NewItemPool(tube, poolSizeTube);
        StartCoroutine(Spawner());
    }
}
