using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GemDataHolder holder;
    [SerializeField] private int startNumberToSpawn;
    [SerializeField] private float delayBetweenSpawn;

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(SpawnGems(delayBetweenSpawn, startNumberToSpawn));
    }

    public void SpawnBurst(float burstCount)
    {
        Debug.Log("SpawnBurst");
        StartCoroutine(SpawnGems(delayBetweenSpawn, burstCount));
    }

    private IEnumerator SpawnGems(float delay, float numberToSpawn)
    {
        int currentNumber = 0;

        while (currentNumber < numberToSpawn)
        {
            var randomPoint = GetRandomPointInBounds(boxCollider.bounds);

            var temp = holder.GenerateRandom();
            var inst = Instantiate(temp.Prefab, randomPoint, Quaternion.identity);
            holder.AddGemToList(inst.GetComponent<Gem>());
            currentNumber++;
            yield return new WaitForSeconds(delay);
            Debug.Log(temp.Name);
        }

        yield return null;
    }

    private Vector2 GetRandomPointInBounds(Bounds bounds)
    {
        var randomPointX = Random.Range(bounds.min.x, bounds.max.x);
        var randomPointY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomPointX, randomPointY);
    }
}
