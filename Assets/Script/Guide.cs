using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneNameToLoad = "GuideKey"; // Ҫ���صĳ�������


    // ����ť�����ʱ���õķ���
    public void SwitchScene()
    {
        // ����ָ���ĳ���
        if (!string.IsNullOrEmpty(sceneNameToLoad))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNameToLoad);
        }
        else
        {
            Debug.LogError("��������δ���ã�");
        }
    }
}
