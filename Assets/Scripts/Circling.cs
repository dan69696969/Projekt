using UnityEngine;

public class Circling : MonoBehaviour
{
    [Header("Rychlost ot��en� (stupn� za sekundu)")]
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
