using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

#if UNITY_EDITOR
public class GridManager : MonoBehaviour
{
    [SerializeField] private int gridHeight;
    [SerializeField] private int gridWidht;
    [SerializeField] private float gridDistance = 1.2f;
    [SerializeField] private GameObject grid;
    [SerializeField] private List<SpawnGridInfo> spawnGridInfos;
    
    private List<Grid> gridsList = new();
    private Grid[] gridsArray;
    private int spawnCount = 0;
    private void Start()
    {
        gridsArray = GetComponentsInChildren<Grid>();
        gridsList = gridsArray.ToList();

        for (int i = 0; i < spawnGridInfos.Capacity; i++)
        {
            for (int j = 0; j < spawnGridInfos[i].spawnGemCount; j++)
            {
                gridsList[spawnCount].CreateGem(spawnGridInfos[i].spawnGemTypePool);
                spawnCount++;
            }
        }
    }
    public void CreateGrid()
    {
        gridsList.Clear();
        for (int i = 0; i < gridWidht; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                var newGrid = Instantiate(grid, transform.position + Helper.Help(i * gridDistance, 0, j * gridDistance), Quaternion.identity, transform);
                gridsList.Add(newGrid.GetComponent<Grid>());
            }
        }
    }
    [CustomEditor(typeof(GridManager))]
    public class PositionCreatorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GridManager generator = (GridManager)target;
            if (GUILayout.Button("Generate Grid"))
            {
                generator.CreateGrid();
            }
        }
    }
}
#endif
