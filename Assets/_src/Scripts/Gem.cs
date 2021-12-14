using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gem : MonoBehaviour, IClickable
{
    [SerializeField] private GemData dataReference;

    public void ClickAction()
    {
        throw new System.NotImplementedException();
    }

    public Gem GetCurrentGem()
    {
        return this;
    }

    public GemData GetCurrentGemData()
    {
        return dataReference;
    }
}
