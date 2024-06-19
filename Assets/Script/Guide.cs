using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneNameToLoad = "GuideKey"; // 要加载的场景名称


    // 当按钮被点击时调用的方法
    public void SwitchScene()
    {
        // 加载指定的场景
        if (!string.IsNullOrEmpty(sceneNameToLoad))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNameToLoad);
        }
        else
        {
            Debug.LogError("场景名称未设置！");
        }
    }
}
