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

    public UIInteractInfo(KeyCode availableKeyCode, string info)
    {
        this.availableKeyCode = availableKeyCode;
        this.info = info;
    }
}
