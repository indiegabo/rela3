using System.Collections;
using System.Collections.Generic;
using IndieGabo.Rela3;
using UnityEditor;
using UnityEngine;

public class Rela3Logger : GLogger
{
    public static Rela3Logger I;

    protected virtual void Awake()
    {
        I = this;
    }

    public void LogTile(Tile tile, string message = null)
    {
        Debug.Log($"<color={warningHEX}>-------------------</color>");
        Debug.Log($"<color={whiteHEX}> {tile.item.name} </color> <color={successHEX}>[{tile.position.x}][{tile.position.y}]</color>");
        if (message != null)
            Debug.Log($"<color={whiteHEX}>{message}</color>");
    }

    public void LogPath(List<Tile> path, string message = null)
    {
        Debug.Log($"<color={successHEX}>------ PATH ---------</color>");

        foreach (Tile tile in path)
        {
            LogTile(tile);
        }

        if (message != null)
            Debug.Log($"<color={whiteHEX}>{message}</color>");
    }


    [MenuItem("GameObject/GLogger/Tile")]
    public static void CreateSeparator(MenuCommand menuCommand)
    {
        GameObject logger = new GameObject("Rela3Logger");
        logger.AddComponent<Rela3Logger>();
        GameObjectUtility.SetParentAndAlign(logger, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(logger, "Create " + logger.name);
        Selection.activeObject = logger;
    }
}
