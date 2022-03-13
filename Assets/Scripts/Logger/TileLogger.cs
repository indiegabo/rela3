using System.Collections;
using System.Collections.Generic;
using IndieGabo.Rela3;
using UnityEditor;
using UnityEngine;

public class TileLogger : GLogger
{
    public static TileLogger I;

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


    [MenuItem("GameObject/GLogger/Tile")]
    public static void CreateSeparator(MenuCommand menuCommand)
    {
        GameObject logger = new GameObject("TileLogger");
        logger.AddComponent<TileLogger>();
        GameObjectUtility.SetParentAndAlign(logger, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(logger, "Create " + logger.name);
        Selection.activeObject = logger;
    }
}
