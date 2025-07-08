using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private uint initPoolSize;
    [SerializeField] private PooledObject objectToPool;

    private Stack<PooledObject> stack;

    private void Start()
    {
        SetupPool();
        InvokeRepeating("GetPooledObject", 0f, 0.2f);
    }

    private void SetupPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;
        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    public PooledObject GetPooledObject()
    {
        if(stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            newInstance.transform.position = newInstance.Pool.transform.position;
            return newInstance;
        }
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        nextInstance.transform.position = nextInstance.Pool.transform.position;
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
