using UnityEngine;

public class FactoryA : Factory
{
    [SerializeField] private ProductA productPrefab;
    public override IProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();
        newProduct.Initialize();
        return newProduct;
    }

    private void Start()
    {
        InvokeRepeating("SpawnProduct", 0f, 2f);
    }

    void SpawnProduct()
    {
        GetProduct(transform.position);
    }
}
