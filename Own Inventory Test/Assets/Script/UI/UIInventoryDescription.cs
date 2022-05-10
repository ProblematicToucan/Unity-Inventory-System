using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDescription : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;

    private void Awake() {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this.itemImage.gameObject.SetActive(false);
        this.quantityText.text = "";
        this.itemName.text = "";
        this.itemDescription.text = "";
    }

    public void SetDescription(Sprite sprite, string name, string description)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.itemName.text = name;
        this.itemDescription.text = description;
    }
}
