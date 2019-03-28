using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int FloorCount;
    public List<Vector3> Floors = new List<Vector3>();
    public List<Transform> PathMaker = new List<Transform>();
    public Transform PathMakerPrefab;

    public int MaxCount;

    public static LevelManager Singleton;

    public Vector3 newSpawnPos;

    public float MaxX;
    public float MinX;
    public float MaxZ;
    public float MinZ;
    private float maxRange;
    private float zRange;
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
        Vector3 cumulatePos = new Vector3((MaxX + MinX)/2, 0, (MaxZ + MinZ)/2);

        maxRange = Mathf.Max(MaxX - MinX, MaxZ - MinZ);


        Vector3 targetPos = cumulatePos + Vector3.up * Mathf.Clamp(20 + maxRange, 0, 450);
        if (Vector3.Distance(transform.position, targetPos) > 10f)
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
        if (FloorCount < MaxCount && PathMaker.Count == 0)
        {
            NewStartingPoint();
            var newPM = Instantiate(PathMakerPrefab, newSpawnPos, Quaternion.identity);
            Debug.Log(newPM.transform.position);
//            PathMaker.Add(newPM);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("load");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



    void NewStartingPoint()
    {
        var randomExistedPos = Floors[Random.Range(0, FloorCount - 2)];
        var adjacentPos1 = randomExistedPos + Vector3.back * 5;
        var adjacentPos2 = randomExistedPos + Vector3.forward * 5;
        var adjacentPos3 = randomExistedPos + Vector3.left * 5;
        var adjacentPos4 = randomExistedPos + Vector3.right * 5;
        foreach (var pos in Floors)
        {
            if (Vector3.Distance(pos, adjacentPos1) > 5)
            {
                newSpawnPos = adjacentPos1;
                return;
            }
            if (Vector3.Distance(pos, adjacentPos2) > 5)
            {
                newSpawnPos = adjacentPos2;
                return;
            }
            if (Vector3.Distance(pos, adjacentPos3) > 5)
            {
                newSpawnPos = adjacentPos3;
                return;
            }
            if (Vector3.Distance(pos, adjacentPos4) > 5)
            {
                newSpawnPos = adjacentPos4;
                return;
            }           
        }
        NewStartingPoint();
    }
}
