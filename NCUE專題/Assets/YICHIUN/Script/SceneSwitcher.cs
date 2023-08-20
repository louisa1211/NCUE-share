using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public float delayTime = 3f;
    public string SceneName;

    private void Start()
    {
        StartCoroutine(SwitchToNextSceneAfterDelay());
    }

    private IEnumerator SwitchToNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(SceneName);
    }
}

