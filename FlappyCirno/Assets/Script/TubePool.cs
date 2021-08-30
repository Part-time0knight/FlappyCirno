using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubePool : MonoBehaviour, IPool
{
    [SerializeField] private GameObject Tube;
    [SerializeField] private int size = 10;
    private readonly Queue<GameObject> items = new Queue<GameObject>();
    public GameObject item {
        get
        {
            if (items.Count == 0)
                items.Enqueue(CreateItem());
            return items.Dequeue();
        }
        set
        {
            value.SetActive(false);
            items.Enqueue(value);
        }
    }
    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            items.Enqueue(CreateItem());
        }
    }
    private GameObject CreateItem()
    {
        GameObject item = Instantiate(Tube);
        item.SetActive(false);
        return item;
    }

    public void ItemSet(GameObject item)
    {
        
    }

}
