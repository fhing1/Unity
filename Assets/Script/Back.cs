using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public string sceneName = "SampleScene"; // Ҫ���صĳ�������


    // ����ť�����ʱ���õķ���
    public void Switchmain()
    {
        // ����ָ���ĳ���
        if (!string.IsNullOrEmpty(sceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("��������δ���ã�");
        }
    }
}
