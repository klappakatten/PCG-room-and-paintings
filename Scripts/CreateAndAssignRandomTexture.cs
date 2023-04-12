using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndAssignRandomTexture : MonoBehaviour
{

    public bool assignNewTexutre = false;

    public List<Texture2D> textures;

    private MeshRenderer rend;
    private Material mat;

    private void OnEnable()
    {
        AssignRandomTexture();
    }

    private void OnValidate()
    {
        if (assignNewTexutre) AssignRandomTexture(); assignNewTexutre = false;
    }

    private void AssignRandomTexture()
    {
        rend = GetComponent<MeshRenderer>();
        if (!mat) { mat = new Material(Shader.Find("Universal Render Pipeline/Lit")); }
        mat.mainTexture = textures[Random.Range(0, textures.Count)];
        rend.material = mat;
    }

}
