using UnityEngine;

public class ProductA : MonoBehaviour, IProduct
{
    [SerializeField] private string productName = "ProductA";
    public string ProductName { get => productName; set => productName = value; }
    private ParticleSystem particle;
    private Rigidbody rb;

    public void Initialize()
    {
        gameObject.name = productName;

        particle = GetComponentInChildren<ParticleSystem>();
        particle?.Stop();
        particle?.Play();

        rb = GetComponent<Rigidbody>();
        rb?.AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
    }
}