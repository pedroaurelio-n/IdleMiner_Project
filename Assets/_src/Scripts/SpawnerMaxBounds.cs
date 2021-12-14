using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMaxBounds : MonoBehaviour
{
    public List<Gem> GemsInMaxBounds;

    [SerializeField] private GemSpawner spawner;
    [SerializeField] private int burstCount;

    private void ActivateNewSpawns()
    {
        spawner.SpawnBurst(burstCount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Gem gem))
        {
            GemsInMaxBounds.Add(gem);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Gem gem))
        {
            if (GemsInMaxBounds.Contains(gem))
                GemsInMaxBounds.Remove(gem);
            
            if (GemsInMaxBounds.Count == 0)
                ActivateNewSpawns();
        }
    }
}
