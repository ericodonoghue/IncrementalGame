using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // Set in inspector 
    public Transform blockPrefab;

    private float timer = 1.0f;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Vector2 randPos = new Vector2(Random.Range(-13f, 13f), Random.Range(-4.5f, 4.5f));
            var block = Instantiate(blockPrefab, randPos, transform.rotation);
            timer = Random.Range(3, 10);

        }
    }
}
