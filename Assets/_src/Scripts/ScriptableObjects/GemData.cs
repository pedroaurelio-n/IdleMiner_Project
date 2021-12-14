using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects/GemData", menuName = "New Gem Data")]
public class GemData : ScriptableObject
{
    public string Name;
    public float BaseWeight;
    public GameObject Prefab;
}