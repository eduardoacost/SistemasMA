using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectordePais : MonoBehaviour
{
    public string level ;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Interface" + level);
    }
}
