using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManagerObject : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.MergeScenes(SceneManager.GetSceneByBuildIndex(1), SceneManager.GetActiveScene());
        // SceneManager.MergeScenes(SceneManager.GetSceneByBuildIndex(2), SceneManager.GetActiveScene());
        // SceneManager.MergeScenes(SceneManager.GetSceneByBuildIndex(3), SceneManager.GetActiveScene());
        Debug.Log("DONE");
    }
}
