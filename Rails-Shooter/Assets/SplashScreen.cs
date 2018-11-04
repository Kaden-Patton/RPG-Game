using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    [SerializeField] float loadDelay = 5f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke("LoadFirstScene", loadDelay);
    }


    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
        
    }
}
	
