using UnityEngine;

public interface IObjectPool<T>
{
    GameObject prefab { get; set; }
    T GetFirstAvailableObject();
    void ReturnObjectToPool(T obj);
    void DisableAllObjects();
}