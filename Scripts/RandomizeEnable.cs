using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeEnable : MonoBehaviour
{

    public bool enableObject = false;
    public float chanceToEnable = 0.5f;

    public List<GameObject> objectsToDisable;

    private void OnEnable()
    {
        enableRandom();
    }

    private void OnValidate()
    {
        if (enableObject) enableRandom(); enableObject = false;
    }

    private void enableRandom()
    {
        if (Random.value > chanceToEnable)
        {
            foreach(GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(true);
            }
        }
    }


}
