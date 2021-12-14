using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDisplayer : MonoBehaviour
{
    [SerializeField] private GemDataHolder holder;

    private void Start()
    {
        var temp = holder.GenerateRandom();
        Debug.Log(temp.Name);

        var inst = Instantiate(temp.Prefab, transform.position, Quaternion.identity);
    }
}
