using DG.Tweening;
using System;
using System.Collections;
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
    [HelpBox("GetItem", HelpBoxType.Info)]
    public GameObject paenl_GetItem;
    public GameObject itemContent;
    public Button button_CloseItem;
    public Image itemImage;
    public Text itemGotNum;
    public Text itemStockNum;
    public Text itemName;
    public Text itemDesc;
    [SerializeField]
    float itemOpenTime = 1f;
    [SerializeField]
    float itemCloseTime = 0.5f;
    public void UIOpenGetItem(Item item)
    {
        button_CloseItem.interactable = false;
        itemImage = item.sprite;
        itemGotNum.text = item.Count.ToString();
        ItemManager.Instance.AddItem(item);
        itemStockNum.text = ItemManager.Instance.GetCount(item).ToString();
        itemName.text = item.Name.ToString();
        itemDesc.text = item.Description.ToString();
        paenl_GetItem.SetActive(true);
        itemContent.transform.localScale = Vector3.zero;
        itemContent.transform.DOScale(1f, itemOpenTime).SetEase(Ease.OutBounce);
        StartCoroutine(nameof(UIOpenGetItem_2));
    }
    IEnumerator UIOpenGetItem_2()
    {
        yield return new WaitForSeconds(itemOpenTime + 0.2f);
        button_CloseItem.interactable = true;
    }
    public Action closeItemCallback;
    public void Call_Co_UICloseGetItem()
    {
        button_CloseItem.interactable = false;
        StartCoroutine(nameof(UICloseGetItem));
    }
    IEnumerator UICloseGetItem()
    {
        itemContent.transform.DOScale(0f, itemCloseTime).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(itemCloseTime+0.2f);
        paenl_GetItem.SetActive(false);
        closeItemCallback?.Invoke();
        yield break;
    }
    #endregion
    #region Puzzle
    [HelpBox("Puzzle", HelpBoxType.Info)]
    public UIPuzzle curPuzzle;
    [HideInInspector]
    public Action puzzleCallback;
    
    public void UIShowPuzzle(GameObject tarPuzzle)
    {
        //TODO ShowPuzzle
        tarPuzzle.SetActive(true);
    }
    public void UICheckPuzzle()
    {
        curPuzzle.CheckPuzzle();
        UIClosePuzzle(curPuzzle.gameObject);
    }
    public void UIClosePuzzle(GameObject tarPuzzle)
    {
        //TODO ClosePuzzle
        tarPuzzle.SetActive(false);
        puzzleCallback?.Invoke();
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
 