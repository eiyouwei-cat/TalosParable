using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("UIInteract")]
    [SerializeField]
    List<UIInteractInfo> uiInteracts = new List<UIInteractInfo>();
    [SerializeField]
    GameObject panel_UIInteract;
    [SerializeField]
    GameObject prefab_UIInteract;
    private void Awake()
    {
        //RefreshUIInteract();
    }
    public void Initialize()
    {
        RefreshUIInteract();
    }
    #region UI Interact
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
        ClearActiveChild(panel_UIInteract.transform.GetChild(0).GetChild(0));
        panel_UIInteract.SetActive(uiInteracts.Count != 0);
        for(int i = 0;i< uiInteracts.Count; i++)
        {
            GameObject g = Instantiate(prefab_UIInteract,panel_UIInteract.transform.GetChild(0).GetChild(0));
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
 