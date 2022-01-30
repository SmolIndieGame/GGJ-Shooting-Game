using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPooled<T> where T : MonoBehaviour, IObjectPooled<T>
{
    PoolHandler<T> poolHandler { get; set; }

    void OnGet();
    void OnReturn();
}

public class PoolHandler<T> where T : MonoBehaviour, IObjectPooled<T>
{
    readonly GameObject prefab;
    readonly Queue<T> pool;

    public PoolHandler(GameObject prefab)
    {
        this.prefab = prefab;
        pool = new Queue<T>();
    }

    public T Spawn()
    {
        T obj;
        if (pool.Count > 0)
            obj = pool.Dequeue();
        else
        {
            obj = Object.Instantiate(prefab).GetComponent<T>();
            obj.poolHandler = this;
        }
        obj.OnGet();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        obj.OnReturn();
        pool.Enqueue(obj);
    }
}