using UnityEngine;
public interface IPool
{
    public GameObject item { get; set; }
    public void ItemSet(GameObject item);
}
