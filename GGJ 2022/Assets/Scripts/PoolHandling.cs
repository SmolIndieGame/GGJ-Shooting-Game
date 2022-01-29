using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPooled<T> where T : MonoBehaviour, IObjectPooled<T>
{
    PoolHandler<T> poolHandler { get; set; }

    void OnGet();
    void OnReturn();
}

public abstract class PoolHandler<T> : MonoBehaviour where T : MonoBehaviour, IObjectPooled<T>
{
    protected abstract GameObject prefab { get; }

    protected Queue<T> pool = new Queue<T>();

    protected virtual T Spawn()
    {
        T obj;
        if (pool.Count > 0)
            obj = pool.Dequeue();
        else
        {
            obj = Instantiate(prefab).GetComponent<T>();
            obj.poolHandler = this;
        }
        obj.OnGet();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public virtual void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        obj.OnReturn();
        pool.Enqueue(obj);
    }
}