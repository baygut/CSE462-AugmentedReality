using UnityEngine;

public class PointCloudAlignment : MonoBehaviour
{
    public TextAsset pointCloud1File;
    public TextAsset pointCloud2File;
    public Material lineMaterial; // Assign a material with a shader that supports color (e.g., Standard Shader)

    void Start()
    {
        // Read point clouds from text files
        Vector3[] points1 = ReadPointCloud(pointCloud1File);
        Vector3[] points2 = ReadPointCloud(pointCloud2File);

        // Align point clouds and draw lines
        AlignAndDrawLines(points1, points2);
    }

    Vector3[] ReadPointCloud(TextAsset file)
    {
        string[] lines = file.text.Split('\n');
        Vector3[] points = new Vector3[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(' ');
            float x = float.Parse(values[0]);
            float y = float.Parse(values[1]);
            float z = float.Parse(values[2]);
            points[i] = new Vector3(x, y, z);
        }

        return points;
    }

    void AlignAndDrawLines(Vector3[] points1, Vector3[] points2)
    {
        // Calculate the translation vector to align the centroids of both point clouds
        Vector3 centroid1 = CalculateCentroid(points1);
        Vector3 centroid2 = CalculateCentroid(points2);
        Vector3 translationVector = centroid2 - centroid1;

        // Translate points1 to align with points2
        Vector3[] alignedPoints1 = new Vector3[points1.Length];
        for (int i = 0; i < points1.Length; i++)
        {
            alignedPoints1[i] = points1[i] + translationVector;
        }

        // Draw lines between corresponding points
        for (int i = 0; i < points1.Length; i++)
        {
            GameObject line = new GameObject("LineRenderer");
            line.transform.parent = this.transform;
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.startWidth = 0.02f; // Set the width of the line as needed
            lineRenderer.endWidth = 0.02f;

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, alignedPoints1[i]);
            lineRenderer.SetPosition(1, points2[i]);
        }
    }

    Vector3 CalculateCentroid(Vector3[] points)
    {
        Vector3 centroid = Vector3.zero;

        foreach (Vector3 point in points)
        {
            centroid += point;
        }

        return centroid / points.Length;
    }
}
