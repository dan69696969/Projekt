using UnityEngine;

public class Circling : MonoBehaviour
{
    [Header("Rychlost otáèení (stupnì za sekundu)")]
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
