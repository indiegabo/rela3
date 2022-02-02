using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = new Vector3(Random.Range(0, 7), Random.Range(0, 7), 0);
            Debug.Log(Board.GetTile(position).name);
        }
    }
}
