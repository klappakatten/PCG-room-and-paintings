using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeEnableFromList : MonoBehaviour
{
    public bool activateRandom = false;
    public List<GameObject> objects;

    private void OnEnable()
    {
        ActivateRandomObject();
    }

    private void OnValidate()
    {
        if (activateRandom) ActivateRandomObject(); activateRandom = false;
    }

    void ActivateRandomObject()
    {

        int randomNumber = Random.Range(0,objects.Count);

        for(int i = 0; i < objects.Count; i++)
        {
            if (i == randomNumber)
            {
                objects[i].SetActive(true);
            }
            else
            {
                objects[i].SetActive(false);
            }
        }
    }

}
