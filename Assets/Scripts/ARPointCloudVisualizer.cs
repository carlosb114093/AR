using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Visualiza los puntos detectados por AR Foundation sin crear miles de objetos nuevos.
/// </summary>
[RequireComponent(typeof(ARPointCloud))]
public class ARPointCloudVisualizer : MonoBehaviour
{
    [SerializeField]
    GameObject pointPrefab; // Prefab del punto (esfera pequeña)

    ARPointCloud pointCloud;
    readonly List<GameObject> points = new();

    void Awake()
    {
        pointCloud = GetComponent<ARPointCloud>();
    }

    void OnEnable()
    {
        pointCloud.updated += OnPointCloudUpdated;
    }

    void OnDisable()
    {
        pointCloud.updated -= OnPointCloudUpdated;
        ClearPoints();
    }

    void OnPointCloudUpdated(ARPointCloudUpdatedEventArgs eventArgs)
    {
        if (pointCloud.positions == null) return;

        // Ajustar número de puntos existentes a la cantidad detectada
        int count = pointCloud.positions.Value.Length;
        while (points.Count < count)
        {
            var point = Instantiate(pointPrefab, transform);
            point.SetActive(true);
            points.Add(point);
        }

        // Si sobran puntos, desactivarlos
        for (int i = count; i < points.Count; i++)
            points[i].SetActive(false);

        // Actualizar posiciones
        int index = 0;
        foreach (var pos in pointCloud.positions.Value)
        {
            if (index < points.Count)
                points[index].transform.localPosition = pos;
            index++;
        }
    }

    void ClearPoints()
    {
        foreach (var point in points)
            Destroy(point);
        points.Clear();
    }
}
