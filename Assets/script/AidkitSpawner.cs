using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkitPrefab;
    private Aidkit _aidkit;
    public List<Transform> spawnerPoints;

    public float delayMin = 3;
    public float delayMax = 9;

    private void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;
        Invoke("CreatAidkit", Random.Range(delayMin, delayMax));
    }
    private void CreatAidkit()
    {
        _aidkit = Instantiate(aidkitPrefab);
        _aidkit.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Count)].position;
    }
}
