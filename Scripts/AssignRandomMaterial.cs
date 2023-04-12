using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomMaterial : MonoBehaviour
{
    public bool changeMaterial = false;

    public List<Material> materials;
    private MeshRenderer rend;

    void OnEnable()
    {

        AssignRandomMat();
    }

    private void OnValidate()
    {
        if (changeMaterial) AssignRandomMat(); changeMaterial = false;
    }

    private void AssignRandomMat()
    {
        if(!rend)rend = GetComponent<MeshRenderer>();
        if (materials.Count>0) rend.material = materials[Random.Range(0, materials.Count)];
    }


}
