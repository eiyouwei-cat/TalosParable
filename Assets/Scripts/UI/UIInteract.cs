using UnityEngine;
using UnityEngine.UI;


public class UIInteract :MonoBehaviour
{
    public Text text_availableKeyCode;
    public Text text_info;
}
public class UIInteractInfo
{
    public KeyCode availableKeyCode;
    public string info;
    public SimpleResult simpleResult;

    public UIInteractInfo(KeyCode availableKeyCode, string info, SimpleResult simpleResult)
    {
        this.availableKeyCode = availableKeyCode;
        this.info = info;
        this.simpleResult = simpleResult;
    }
}
