using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public static int activeItemIndex;
    [SerializeField] public static float moveSpeed = 5f;
    public static List<Color> items = new List<Color>();
    [SerializeField] public Image itemImageHolder;
    private void Update()
    {
        UseItem();
        CycleItems();
    }
    public void UseItem()
    {

        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {

            if (items[activeItemIndex] == Color.blue)
            {
                StartCoroutine(GetComponent<Text>().ShowMessage(" + Move Speed"));
                moveSpeed += 5;
            }
            else if (items[activeItemIndex] == Color.red)
            {
                StartCoroutine(GetComponent<Text>().ShowMessage(" + Fire Rate"));
                ShipBehaviour.cooldownTime -= 0.1f;
            }
            else if (items[activeItemIndex] == Color.green)
            {
                StartCoroutine(GetComponent<Text>().ShowMessage(" + Rotation Speed"));
                ShipBehaviour.rotationSpeed += 10;
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }

        }
    }
    public void PickUpItem(GameObject item)
    {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);

        ItemUse.items.Add(color);

        activeItemIndex = ItemUse.items.Count - 1;

        itemImageHolder.color = ItemUse.items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (ItemUse.items.Count > 0)
            {
                if (activeItemIndex < ItemUse.items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = ItemUse.items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }

    }
}