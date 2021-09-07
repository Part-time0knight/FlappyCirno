using UnityEngine;

public interface IItemSpawner
{
    public bool pause { get; set; }
    public void StartSpawn(GameObject item, float speed);
}
