using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Script_GameManager : MonoBehaviour
{

public static Script_GameManager instance = null;

void Awake()
{
    if (instance == null)
    {
        instance = this;
    }
    else
    {
        Destroy(gameObject);
        return;
    }

    DontDestroyOnLoad(this);
}

}
