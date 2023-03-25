using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeshPicker : MonoBehaviour
{
    public MeshFilter mesh;
    [SerializeField] TMP_Text selectedMeshText;

    private void Start()
    {
        selectedMeshText.text = "Selected mesh: " + DataFlow.Instance.meshInGame.name;
    }

    public void SetNewMesh()
    {
        DataFlow data = DataFlow.Instance;
        data.meshInGame = mesh;
        selectedMeshText.text = "Selected mesh: " + mesh.name;
    }

    private void OnMouseUp()
    {
        SetNewMesh();
    }
}
