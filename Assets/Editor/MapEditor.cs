using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GeneratedMap))]
public class MapEditor : Editor {

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		var generatedMap = target as GeneratedMap;
		generatedMap.Initialize();
	}
}