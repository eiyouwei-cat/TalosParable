using System.Collections.Generic;
using UnityEngine;

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
 