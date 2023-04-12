using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralModuleGenerator : MonoBehaviour
{

    public bool generateNewVariant = false;
    public bool generateNewMaterials = false;

    [SerializeField] private List<Module> moduleLists;

    [SerializeField] private List<Material> materialList;

    [System.Serializable]
    public struct Module
    {
        public List<GameObject> moduleList;
    }

    protected void OnEnable()
    {
        GenerateObject();
    }

    protected void OnValidate()
    {
        if (generateNewVariant) GenerateObject(); generateNewVariant = false;
        if (generateNewMaterials) AssignRandomMaterial(); generateNewMaterials = false;
    }


    private void GenerateObject()
    {
        for (int i = 0; i < moduleLists.Count; i++)
        {
            ActivateRandomModule(moduleLists[i].moduleList);
        }
        AssignRandomMaterial();
    }

    private void ActivateRandomModule(List<GameObject> list)
    {
        int randomIndex = Random.Range(0, list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            if (i == randomIndex)
            {
                if (list[i] == null) continue;
                list[i].gameObject.SetActive(true);
            }
            else {
                if (list[i] == null) continue;
                list[i].gameObject.SetActive(false); }
        }
    }

    private void AssignRandomMaterial()
    {

        Renderer[] childrenRenderer = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < childrenRenderer.Length; i++)
        {
            Renderer currentRenderer = childrenRenderer[i];
            if (currentRenderer.materials.Length > 1)
            {
                Material[] materials = new Material[] { materialList[Random.Range(0, materialList.Count)], materialList[Random.Range(0, materialList.Count)] };
                currentRenderer.materials = materials;
            }
            else if(currentRenderer.materials.Length == 1)
            {
                Material[] materials = new Material[] {materialList[Random.Range(0, materialList.Count)] };
                currentRenderer.materials = materials;
            }
        }
    }



}
