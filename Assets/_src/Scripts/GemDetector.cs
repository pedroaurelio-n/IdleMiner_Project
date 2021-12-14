using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GemDetector : MonoBehaviour
{
    [SerializeField] private GemDataHolder holder;
    [SerializeField] private LayerMask gemLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 10f, gemLayer);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent(out IClickable gem))
                {
                    Debug.Log("Clicked " + gem.GetCurrentGemData().Name);
                    holder.RemoveGemFromList(gem.GetCurrentGem());
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
