// using System.Collections;
// using System.Collections.Generic;
// using IndieGabo.Rela3;
// using IndieGabo.GLogger;
// using UnityEditor;
// using UnityEngine;

// public class TileLogger : GLogger
// {
//     public static TileLogger I;

//     protected virtual void Awake()
//     {
//         I = this;
//     }
//     public void LogTile(Tile tile, string message = null)
//     {
//         Debug.Log($"<color={warningHEX}>-------------------</color>");
//         Debug.Log($"<color={whiteHEX}>Tile: </color> <color={successHEX}>[{tile.position.x}][{tile.position.y}]</color>");
//         Debug.Log($"<color={whiteHEX}>Item: </color> <color={successHEX}>{tile.item.name}</color>");
//         Debug.Log($"<color={warningHEX}>-------------------</color>");
//     }


//     [MenuItem("GameObject/Loggers/Tile")]
//     public static void CreateSeparator(MenuCommand menuCommand)
//     {
//         GameObject separator = new GameObject("TileLogger");
//         separator.AddComponent<TileLogger>();
//         GameObjectUtility.SetParentAndAlign(separator, menuCommand.context as GameObject);
//         Undo.RegisterCreatedObjectUndo(separator, "Create " + separator.name);
//         Selection.activeObject = separator;
//     }
// }
