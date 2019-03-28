using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int FloorCount;
    public List<Vector3> Floors = new List<Vector3>();

    public static LevelManager Singleton;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
//        if (FloorCount >= 500)
//        {
//        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("load");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
