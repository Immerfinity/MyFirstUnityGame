using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject itemInfoPrefab;
    [SerializeField] private GameObject listOfItems;

    private List<Button> buttons = new List<Button>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        foreach (InventoryItem item in Party.Inventory.Items.Keys)
        {
            if (item is UsableItem usableItem)
            {
                ItemInfo itemInfo = Instantiate(itemInfoPrefab, listOfItems.transform).GetComponent<ItemInfo>();
                itemInfo.SetItem(usableItem);
            }
        }

        buttons = GetComponentsInChildren<Button>().ToList();

        if (buttons.Count > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        }
        else
        {
            Debug.LogWarning("No buttons found in ItemList.");
        }

        animator.Play("Open");
    }

    public void Close()
    {
        buttons.Clear();

        foreach (RectTransform child in listOfItems.GetComponent<RectTransform>())
        {
            Destroy(child.gameObject);
        }

        animator.Play("Close");
    }

}
