using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public void LoadingGame()
    {
        SceneManager.LoadScene(0);//第几场景就是几
    }
}
