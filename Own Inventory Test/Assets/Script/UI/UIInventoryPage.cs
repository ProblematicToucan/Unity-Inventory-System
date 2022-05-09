using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;

    [SerializeField] private RectTransform contentPanel;

    [SerializeField] private MouseFollower mouseFollower;

    [SerializeField] private UIInventoryDescription itemDescription;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public Sprite image;
    public int quantity;
    public string nameItem;
    public string descriptionItem;

    private void Awake() {
        Hide();
        mouseFollower.Togle(false);
        itemDescription.ResetDescription();
    }
    public void InitializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel, false);
            listOfUIItems.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRIghtMouseBtnClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(UIInventoryItem obj)
    {
        Debug.Log("Show item actions");
    }

    private void HandleEndDrag(UIInventoryItem obj)
    {
        mouseFollower.Togle(false);
    }

    private void HandleSwap(UIInventoryItem obj)
    {
        Debug.Log("Swap");
    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
        mouseFollower.Togle(true);
        mouseFollower.SetData(image, quantity);
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        itemDescription.SetDescription(image, quantity, nameItem, descriptionItem);
        listOfUIItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();

        listOfUIItems[0].SetData(image, quantity);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
