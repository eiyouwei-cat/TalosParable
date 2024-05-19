using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIManager : Singleton<UIManager>
{
    
    public void Initialize()
    {
        RefreshUIInteract();
    }
    #region Dialog
    [HelpBox("Dialog",HelpBoxType.Info)]
    public Fadable panel_FullLog;
    public TypeWriter text_FullLog;
    public Fadable panel_PartLog;
    public TypeWriter text_PartLog;
    #endregion
    #region GetItem
    public GameObject paenl_GetItem;
    public GameObject content;
    public Image itemImage;
    public Text itemGotNum;
    public Text itemStockNum;
    public Text itemDesc;
    [SerializeField]
    float itemInTime = 0.3f;
    public void UIOpenGetItem(Item item)
    {
        itemImage = item.sprite;
        itemGotNum.text = item.Count.ToString();
        itemStockNum.text = ItemManager.Instance.GetCount(item).ToString();
        itemDesc.text = item.Description.ToString();
        paenl_GetItem.SetActive(true);
        content.transform.localScale = Vector3.zero;
        content.transform.DOScale(1f, itemInTime).SetEase(Ease.OutBounce);
    }
    public Action closeItemCallback;
    public void UICloseGetItem()
    {
        paenl_GetItem.SetActive(false);
        closeItemCallback?.Invoke();
    }
    #endregion
    #region UIInteract
    [HelpBox("UIInteract", HelpBoxType.Info)]
    [SerializeField]
    List<UIInteractInfo> uiInteracts = new List<UIInteractInfo>();
    [SerializeField]
    GameObject content_UIInteract;
    [SerializeField]
    GameObject prefab_UIInteract;
    public void TryAddUIInteract(UIInteractInfo addU)
    {
        if (uiInteracts.Contains(addU))
            return;
        uiInteracts.Add(addU);
        RefreshUIInteract();
    }
    public void TryRemoveUIInteract(UIInteractInfo remU)
    {
        if (!uiInteracts.Contains(remU))
            return;
        uiInteracts.Remove(remU);
        RefreshUIInteract();
    }
    void RefreshUIInteract()
    {
        ClearActiveChild(content_UIInteract.transform);
        content_UIInteract.transform.parent.parent.gameObject.SetActive(uiInteracts.Count != 0);
        for(int i = 0;i< uiInteracts.Count; i++)
        {
            GameObject g = Instantiate(prefab_UIInteract,content_UIInteract.transform);
            g.GetComponent<UIInteract>().text_availableKeyCode.text = uiInteracts[i].availableKeyCode.ToString();
            g.GetComponent<UIInteract>().text_info.text = uiInteracts[i].info.ToString();
            g.SetActive(true);
        }
    }
    #endregion
    void ClearActiveChild(Transform p)
    {
        for(int i = 0;i<p.childCount;i++)
            if(p.GetChild(i).gameObject.activeSelf)
                Destroy(p.GetChild(i).gameObject);
    }
}
 