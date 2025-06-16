using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawn : MonoBehaviour
{
    [SerializeField] Transform[] cometSpawns = new Transform[3];
    [SerializeField] Rigidbody2D cometPrefab;

    void Start()
    {
        StartCoroutine(SpawnComets());
    }

    private IEnumerator SpawnComets()
    {
        while (true)
        {
            float coolDown = Random.Range(4, 9);
            int randomNumber = Random.Range(0, cometSpawns.Length);
            Instantiate(cometPrefab, cometSpawns[randomNumber].position, Quaternion.Euler(0,180,0));
            yield return new WaitForSeconds(coolDown);
        }
    }
}
