using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePosition : MonoBehaviour
{
    public bool randomizePosition;

    public Vector3 maxRandomVal;
    public Vector3 minRandomVal;
    

    private void OnEnable()
    {
        randomizePos();
    }

    private void OnValidate()
    {
        if(randomizePosition) randomizePos(); randomizePosition = false;
    }

    private void randomizePos()
    {
        Vector3 currentPos = gameObject.transform.position;
        Vector3 posOffset = new Vector3(Random.Range(minRandomVal.x, maxRandomVal.x), Random.Range(minRandomVal.y, maxRandomVal.y), Random.Range(minRandomVal.z, maxRandomVal.z));
        Vector3 newPos = new Vector3(currentPos.x + posOffset.x, currentPos.y + posOffset.y,currentPos.z + posOffset.z);
        gameObject.transform.position = newPos;
    }


}
