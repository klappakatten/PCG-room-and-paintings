using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSize : MonoBehaviour
{
    public float maxSize = 1;
    public float minSize = 1;

    private void OnEnable()
    {

        if (Random.value < 0.5f)
            transform.localScale = new Vector3(Random.Range(minSize, maxSize), 1, 1);
        else
        {
            transform.localScale = new Vector3(1, Random.Range(minSize, maxSize), 1);
        }
    }
}
