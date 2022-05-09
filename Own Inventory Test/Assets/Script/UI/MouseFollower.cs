using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [SerializeField] private UIInventoryItem item;

    public void SetData(Sprite sprite, int quantity)
    {
        item.SetData(sprite, quantity);
    }

    private void Update() {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out var position
        );
        transform.position = canvas.transform.TransformPoint(position);
    }

    public void Togle(bool value)
    {
        Debug.Log("Togle " + value);
        gameObject.SetActive(value);
    }
}
