using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerObject: MonoBehaviour
{
    private void Start(){
        SceneManager.MergeScenes(SceneManager.GetSceneByName("Scene1"),SceneManager.GetActiveScene());
        Debug.Log("DONE");

    }
}
 