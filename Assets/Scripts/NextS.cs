using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextS : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene(2);
    }
}
