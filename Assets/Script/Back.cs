using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public string sceneName = "SampleScene"; // 要加载的场景名称


    // 当按钮被点击时调用的方法
    public void Switchmain()
    {
        // 加载指定的场景
        if (!string.IsNullOrEmpty(sceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("场景名称未设置！");
        }
    }
}
