using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemPool : MonoBehaviour, IPool
{
    private readonly List<Queue<GameObject>> items = new List<Queue<GameObject>>();
    private readonly List<GameObject> prefabs = new List<GameObject>();

    public GameObject GetItem(int index)
    {
        if (items[index].Count <= 0)
            items[index].Enqueue(CreateItem(index));
        return items[index].Dequeue();
    }

    public int NewItemPool(GameObject newGameObject, int poolSize)
    {
        int index = items.Count;
        prefabs.Add(newGameObject);
        items.Add(new Queue<GameObject>());
        for (int i = 0; i < poolSize; i++)
        {
            GameObject tempObject = Instantiate(newGameObject);
            tempObject.SetActive(false);
            items[index].Enqueue(tempObject);
        }
        return index;
    }

    public void ReturnItem(GameObject returnObject, int index)
    {
        items[index].Enqueue(returnObject);
        returnObject.SetActive(false);
    }
    private GameObject CreateItem(int index)
    {
        GameObject item = Instantiate(prefabs[index]);
        item.SetActive(false);
        return item;
    }

}
