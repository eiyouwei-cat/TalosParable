using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("UIInteract")]
    [SerializeField]
    List<UIInteract> uiInteracts = new List<UIInteract>();
    [SerializeField]
    GameObject panel_UIInteract;
    private void Awake()
    {
        RefreshUIInteract();
    }
    #region UI Interact
    public void TryAddUIInteract(UIInteract addU)
    {
        if (uiInteracts.Contains(addU))
            return;
        uiInteracts.Add(addU);
        RefreshUIInteract();
    }
    public void TryRemoveUIInteract(UIInteract remU)
    {
        if (!uiInteracts.Contains(remU))
            return;
        uiInteracts.Remove(remU);
        RefreshUIInteract();
    }
    void RefreshUIInteract()
    {
        panel_UIInteract.SetActive(uiInteracts.Count != 0);
    }
    #endregion
}
