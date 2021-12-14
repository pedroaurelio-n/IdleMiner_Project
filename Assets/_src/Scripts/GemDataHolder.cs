using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDataHolder : MonoBehaviour
{
    [SerializeField] private List<GemData> gemData;

    private float totalWeight;

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
