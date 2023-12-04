using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName; // Name of the scene you want to switch to

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("This script should be attached to a GameObject with a Button component.");
        }
    }

    // Call this method to change the scene
    public void ChangeScene()
    {
        Debug.Log("Changing scene to: " + targetSceneName);
        SceneManager.LoadScene(targetSceneName);
    }
}
