using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isNexted = false;

    [SerializeField]
    protected bool usedOnce = false;
    [SerializeField]
    protected bool used = false;

    [SerializeField]
    SimpleCondition[] triggerConditions = null;
    [SerializeField]
    SimpleResult[] triggerResults = null;

    public SimpleResult[] TriggerResults { get => triggerResults; set => triggerResults = value; }

    private void Awake()
    {
        Initialize();
        
    }
    void Initialize()
    {
        triggerConditions = GetComponents<SimpleCondition>();
        if (triggerConditions.Length == 0)
            Debug.LogError("NULL Trigger Condition!");
        TriggerResults = GetComponents<SimpleResult>();
        if(TriggerResults.Length == 0)
            Debug.LogError("NULL Trigger Result!");
    }

    void Update()
    {
        if (isNexted)
            return;
        CheckCondition();
    }
    public bool CheckCondition()
    {
        if (used)
            return false;
        bool satisfied = true;
        foreach (SimpleCondition simpleCondition in triggerConditions)
        {
            if (!simpleCondition.condition.Invoke())
            {
                satisfied = false;
                break;
            }
        }
        
        foreach (SimpleResult simpleResult in TriggerResults)
        {
            satisfied = simpleResult.result.Invoke(satisfied) && satisfied;
        }
        if (satisfied && usedOnce)
        {
            used = true;
            foreach (SimpleResult simpleResult in TriggerResults)
            {
                simpleResult.result.Invoke(false);
            }
        }
           
        return used;
    }
    
    
    
}
