using UnityEditor;
using UnityEngine;
using TD.Spawner;

[CustomEditor(typeof(Spawner))]
public class SInspector : Editor
{
    bool showUnitSection = false;
    bool showWaveSection = true;
    Spawner spawn;
    public override void OnInspectorGUI()
    {
        spawn = (Spawner)target;

        showUnitSection = EditorGUILayout.Foldout(showUnitSection, "Assign Units");
        if (showUnitSection)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Enemy 1");
            spawn.unitList[0] = (GameObject)EditorGUILayout.ObjectField(spawn.unitList[0], typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Enemy 2");
            spawn.unitList[1] = (GameObject)EditorGUILayout.ObjectField(spawn.unitList[1], typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Enemy 3");
            spawn.unitList[2] = (GameObject)EditorGUILayout.ObjectField(spawn.unitList[2], typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();
			
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Boss");
            spawn.unitList[3] = (GameObject)EditorGUILayout.ObjectField(spawn.unitList[3], typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.Space();
        showWaveSection = EditorGUILayout.Foldout(showWaveSection, "Set Waves");
        if (showWaveSection)
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.BeginVertical(GUILayout.MinWidth(150));
                {
                    GUILayout.Label("Unit Level");
                    GUILayout.Label("Number of Units");
                    GUILayout.Label("Spawn Type");
                    GUILayout.Label("Time Between Spawn");
                    switch (spawn.spawnType)
                    {
                        case SpawnModes.Wave:
                            GUILayout.Label("Wave Timer");
                            GUILayout.Label("Number of Waves");
                            break;
                        default:
                            break;
                    }
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical(GUILayout.MinWidth(80));
                {
                    spawn.unitLevel = (UnitLevels)EditorGUILayout.EnumPopup(spawn.unitLevel);
                    spawn.totalUnits = EditorGUILayout.IntField(spawn.totalUnits);
                    spawn.spawnType = (SpawnModes)EditorGUILayout.EnumPopup(spawn.spawnType);
                    spawn.timeBetweenSpawns = EditorGUILayout.FloatField(spawn.timeBetweenSpawns);

                    switch (spawn.spawnType)
                    {
                        case SpawnModes.Wave:
                            spawn.waveTimer = EditorGUILayout.FloatField(spawn.waveTimer);
                            spawn.totalWaves = EditorGUILayout.IntField(spawn.totalWaves);
                            break;
                        default:
                            break;
                    }
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.PrefixLabel("Spawner ID");
            spawn.spawnID = EditorGUILayout.IntField(spawn.spawnID);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.PrefixLabel("Spawn Location");
            spawn.spawnLocation = (Transform)EditorGUILayout.ObjectField(spawn.spawnLocation, typeof(Transform), true);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.PrefixLabel("Spawn");
            spawn.spawn = EditorGUILayout.Toggle(spawn.spawn);
        }
        EditorGUILayout.EndHorizontal();

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
}