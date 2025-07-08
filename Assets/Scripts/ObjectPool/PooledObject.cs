using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool Pool { get => pool; set => pool = value; }
    public float aliveTime = 0f;

    private void Update()
    {
        aliveTime += Time.deltaTime;
        if(aliveTime > 1f)
        {
            Release();
        }
    }

    public void Release()
    {
        pool.ReturnToPool(this);
        aliveTime = 0f;
    }
}
