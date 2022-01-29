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

    protected Queue<T> pool = new Queue<T>();

    protected virtual T Spawn()
    {
        T obj = pool.Count > 0 ? pool.Dequeue() : Instantiate(prefab).GetComponent<T>();
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