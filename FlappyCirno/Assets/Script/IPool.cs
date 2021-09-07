using UnityEngine;
public interface IPool
{
    public int NewItemPool(GameObject newGameObject, int poolSize);
    public GameObject GetItem(int index);
    public void ReturnItem(GameObject returnGameObject, int index);
}
