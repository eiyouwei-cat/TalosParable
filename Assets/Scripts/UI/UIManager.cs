using System;
using System.Collections;
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
    void Update()
    {
        CheckUIInteract();
    }
    #region UI Interact
    void CheckUIInteract()
    {
        if (!panel_UIInteract.activeSelf)
            return;
        if (PlayerStateController.Instance.IsBusy())
            return;
        for(int i = 0; i < uiInteracts.Count; i++)
        {
            if (Input.GetKeyDown(uiInteracts[i].availableKeyCode))
            {
                for(int j = 0; j < uiInteracts[i].func.Length; j++)
                    uiInteracts[i].func[j].Invoke();
                //TODO: remove or not ??
                RefreshUIInteract();
                //panel_UIInteract.SetActive(false);
                return;
            }
        }

    }
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
