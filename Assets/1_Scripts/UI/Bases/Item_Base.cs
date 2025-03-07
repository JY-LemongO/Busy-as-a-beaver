using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Base : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text item_Name;
    public TMP_Text item_Description;
    public TMP_Text item_Count;

    public ItemData itemData;
    public GameObject parent;

    #region LifeCycle
    
    #endregion

    public void OnClick_Item()
    {
        //아이템 사용 시 무작위 비버에게 아이템 효과 발동
        //갯수가 있을때만 발동, 갯수 하나 차감
        Debug.Log("로직 구현중 ");

        parent.SetActive(false);
    }

    public void Initialize(ItemData data)
    {   
        itemData = data;

        itemIcon.sprite = GameManager.Instance.Settings.icon_Item_dict[itemData.model];
        item_Name.text = itemData.itemName;
        item_Description.text = itemData.description;
        
        switch(itemData.itemType)
        {
            case ItemType.Apple:
                item_Count.text = DataManager.Instance.statusData[StatusType.Item_Apple].statusValue.ToString();
                break;
            case ItemType.Banana:
                item_Count.text = DataManager.Instance.statusData[StatusType.Item_Banana].statusValue.ToString();
                break;
            case ItemType.Peach:
                item_Count.text = DataManager.Instance.statusData[StatusType.Item_Peach].statusValue.ToString();
                break;
        }
    }
}
