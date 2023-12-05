using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class PointCloudVisualizer : MonoBehaviour
{
    public string filePath; // Fill in with the path to your TXT file
    public GameObject pointPrefab; // Assign a sphere prefab in the Unity Editor

    void Start()
    {
        List<Vector3> pointCloud = ReadPointCloud(filePath);
        InstantiatePoints(pointCloud);
    }

    List<Vector3> ReadPointCloud(string filePath)
    {
        List<Vector3> points = new List<Vector3>();

        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Parse each line to extract the 3D point coordinates
            for (int i = 1; i < lines.Length; i++)
            {
                string[] coordinates = lines[i].Split(' ');

                if (coordinates.Length == 3)
                {
                    float x = float.Parse(coordinates[0]);
                    float y = float.Parse(coordinates[1]);
                    float z = float.Parse(coordinates[2]);

                    Vector3 point = new Vector3(x, y, z);
                    points.Add(point);
                }
                else
                {
                    Debug.LogError("Invalid data format in line " + (i + 1) + ": " + lines[i]);
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("File not found: " + filePath + e);
        }

        return points;
    }

    void InstantiatePoints(List<Vector3> points)
    {
        foreach (Vector3 point in points)
        {
            Instantiate(pointPrefab, point, Quaternion.identity);
        }
    }
}
