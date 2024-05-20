using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    
    List<Level> levels = new List<Level>();
    [SerializeField]
    ObservableValue<Level> curLevel;
    

    public void Initialize()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            levels.Add(transform.GetChild(i).GetComponent<Level>());
        }
        curLevel = new ObservableValue<Level>(null, OnCurLevelChange);
    }
    public void UIEnterLevel(int levelId)
    {
        if(!(levelId >= 0 && levelId < levels.Count))
        {
            Debug.LogError("INVALID levelID : " + levelId);
            return;
        }    
        curLevel.Value = levels[levelId];
    }
    void OnCurLevelChange(Level oldV,Level newV)
    {
        oldV?.OnLeaveLevel();
        Debug.Log("OnCurLevelChange : newV = " + levels.IndexOf(newV));
        newV.OnEnterLevel();
    }
    
}
