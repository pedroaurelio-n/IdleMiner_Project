using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDataHolder : MonoBehaviour
{
    public List<Gem> GemsInScene = new List<Gem>();
    [SerializeField] private List<GemData> gemData;

    private float totalWeight;

    public void AddGemToList(Gem gem)
    {
        GemsInScene.Add(gem);
    }

    public void RemoveGemFromList(Gem gem)
    {
        if (GemsInScene.Contains(gem))
            GemsInScene.Remove(gem);
        else
            Debug.LogError("Tried to remove unknown gem.");
    }

    public GemData GenerateRandom()
    {
        totalWeight = 0;
        foreach(GemData entry in gemData)
        {
            totalWeight += entry.BaseWeight;
            //entry.AccumulatedWeight = totalWeight;
        }

        float rand = Random.Range(0, totalWeight);
        float weightSum = 0;

        foreach(GemData entry in gemData)
        {
            weightSum += entry.BaseWeight;
            if (rand <= weightSum)
            {
                return entry;
            }
        }

        return null;

        /*float rand = Random.Range(1, totalWeight + 1);

        foreach (GemData entry in gemData)
        {
            if (entry.AccumulatedWeight >= rand)
                return entry;
        }

        return null;*/
    }
}
