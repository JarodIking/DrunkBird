using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject Pipe;
    public float SpawnRate = 2;
    public float HeightOffset = 10;
    
    private float Timer = 0;
    private Vector3 PipeSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < SpawnRate)
        {
            IncrementTimer();
            return;
        }
            
        SpawnPipe();
    }

    private void SpawnPipe()
    {
        SetPipeSpawnPosition();
        Instantiate(Pipe, PipeSpawnPosition, transform.rotation);
        ResetTimer();
    }

    private void SetPipeSpawnPosition()
    {
        PipeSpawnPosition = new Vector3(
            transform.position.x, 
            
            Random.Range(
                transform.position.y - HeightOffset,
                transform.position.y + HeightOffset
                ),
            
            0);
    }

    private void IncrementTimer()
    {
        Timer += Time.deltaTime;
    }

    private void ResetTimer()
    {
        Timer = 0;
    }
}
