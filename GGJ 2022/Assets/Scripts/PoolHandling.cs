using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPooled
{
    void OnGet();
    void OnReturn();
}

public abstract class PoolHandler<T> : MonoBehaviour where T : MonoBehaviour, IObjectPooled
{
    protected abstract GameObject prefab { get; }

    Queue<T> pool = new Queue<T>();

    protected virtual T Spawn()
    {
        T obj;
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            obj.OnGet();
            return obj;
        }

        obj = Instantiate(prefab).GetComponent<T>();
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