using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour
{
    public void Start ()
    {

    }
    public void Update () 
    {

    }
    public void PushButton()
    {
        SceneManager.LoadScene("mapページ");
    }
}