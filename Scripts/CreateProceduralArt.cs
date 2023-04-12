using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProceduralArt : MonoBehaviour
{
    public bool generateNewArt = false;

    public bool horizontalClustering = false;
    public bool verticalClustering = false;
    public bool randomizeClustering = true;

    public Texture2D albedo;
    public Material mat;
    public int minColorAmount;
    public int maxColorAmount;
    public int maxWhiteAmount;

    [Range(0, 1)]
    public float minClusteringChance;
    [Range(0, 1)]
    public float maxClusteringChance;

    public float clusteringChance;

    [SerializeField] private int minWidthHeight;
    [SerializeField] private int maxWidthHeight;
    private int widthHeight;

    public List<Color> colorList;
    public List<Color> currentColorsAvailable;

    private MeshRenderer rend;

    public enum Filter { Bilinear, Point, Trilinear }
    public Filter filter = Filter.Point;


    private void OnEnable()
    {
        CreateAndAssignTexture();
    }


    private void OnValidate()
    {
        if (generateNewArt) CreateAndAssignTexture(); generateNewArt = false;
    }

    private void CreateAndAssignTexture()
    {
        widthHeight = Random.Range(minWidthHeight, maxWidthHeight);

        clusteringChance = Random.Range(minClusteringChance, maxClusteringChance);

        if (randomizeClustering)
        {
            if (Random.value > 0.5) verticalClustering = true; else verticalClustering = false;
            if (Random.value > 0.5) horizontalClustering = true; else horizontalClustering = false;
        }


        albedo = new Texture2D(widthHeight, widthHeight);
        mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        rend = gameObject.GetComponent<MeshRenderer>();

        RandomizePicture(albedo, widthHeight, widthHeight);

        ApplyFilterMode();
                
        mat.mainTexture = albedo;
        rend.material = mat;

        currentColorsAvailable.Clear();
    }

    private void AddRandomColors()
    {

        int randColorAmount = Random.Range(minColorAmount, maxColorAmount + 1);
        int randomWhiteAmount = Random.Range(0, maxWhiteAmount);

        for (int i = 0; i < randColorAmount; i++)
        {
            Color randomColor = RandomColor();
            while (currentColorsAvailable.Contains(randomColor))
            {
                randomColor = RandomColor();
            }

            currentColorsAvailable.Add(randomColor);

        }

        while (randomWhiteAmount > 0)
        {
            currentColorsAvailable.Add(Color.white);
            randomWhiteAmount--;
        }

    }

    private Color GetRandomCurrentColor()
    {
        return currentColorsAvailable[Random.Range(0, currentColorsAvailable.Count)];
    }

    private Color RandomColor()
    {
        return colorList[Random.Range(0, colorList.Count)];
    }


    private void RandomizePicture(Texture2D texture, int h, int w)
    {
        AddRandomColors();
        Color lastColor = Color.black;

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                float random = Random.value;
                if (verticalClustering && random <= clusteringChance && j != 0)
                {
                    texture.SetPixel(i, j, lastColor);
                    random = Random.value;
                    if (horizontalClustering && i > 0 && random<0.5)
                    {
                        texture.SetPixel(i - 1, j, texture.GetPixel(i - 1, j));
                    }
                }
                else if (horizontalClustering && i > 0 && random <= clusteringChance)
                {
                    texture.SetPixel(i, j, texture.GetPixel(i - 1, j));
                }

                else
                {
                    lastColor = GetRandomCurrentColor();
                    texture.SetPixel(i, j, lastColor);
                }

            }

        }


        texture.Apply();
    }

    private void ApplyFilterMode()
    {
        switch (filter)
        {
            case Filter.Point:
                albedo.filterMode = FilterMode.Point;
                break;
            case Filter.Bilinear:
                albedo.filterMode = FilterMode.Bilinear;
                break;
            case Filter.Trilinear:
                albedo.filterMode = FilterMode.Trilinear;
                break;
            default:
                albedo.filterMode = FilterMode.Point;
                break;
        }
    }

}
