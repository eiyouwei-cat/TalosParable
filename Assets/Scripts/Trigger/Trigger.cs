using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    protected float conditionCD = 1f;


    [SerializeField]
    protected bool usedOnce = false;
    [SerializeField]
    protected bool used = false;
    [SerializeField]
    protected bool isUsing = false;

    [SerializeField]
    TriggerCondition[] triggerConditions = null;
    [SerializeField]
    TriggerResult[] triggerResults = null;

    private void Awake()
    {
        Initialize();
        
    }
    private void Start()
    {
        StartCoroutine(nameof(CheckCondition));
    }
    void Initialize()
    {
        triggerConditions = GetComponents<TriggerCondition>();
        if (triggerConditions.Length == 0)
            Debug.LogError("NULL Trigger Condition!");
        triggerResults = GetComponents<TriggerResult>();
        if(triggerResults.Length == 0)
            Debug.LogError("NULL Trigger Result!");
    }

    IEnumerator CheckCondition()
    {
        if (used || isUsing)
            yield break;
        while(true)
        {
            bool condition = true;
            for (int i = 0; i < triggerConditions.Length; i++)
            {
                if (!triggerConditions[i].Call())
                {
                    condition = false;
                    break;
                }
            }
            if(!condition)
            {
                yield return new WaitForSeconds(conditionCD);
                continue;
            }
            for (int i = 0; i < triggerResults.Length; i++)
            {
                triggerResults[i].Call();
            }
                
            if (usedOnce)
            {
                used = true;
                yield break;
            }
            yield return new WaitForSeconds(conditionCD);
        }
    }
    
    
    
}
