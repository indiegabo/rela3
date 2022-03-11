using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenericLogger : Logger
{
    public static GenericLogger I;

    protected virtual void Awake()
    {
        I = this;
    }
    public void Success(string message, Object sender = null)
    {
        if (!m_settings.shouldLog) return;
        Log(message, successHEX, sender);
    }

    public void Warning(string message, Object sender = null)
    {
        if (!m_settings.shouldLog) return;
        Log(message, warningHEX, sender);
    }

    public void Danger(string message, Object sender = null)
    {
        if (!m_settings.shouldLog) return;
        Log(message, dangerHEX, sender);
    }

    [MenuItem("GameObject/Loggers/Generic")]
    public static void CreateSeparator(MenuCommand menuCommand)
    {
        GameObject separator = new GameObject("GenericLogger");
        separator.AddComponent<GenericLogger>();
        GameObjectUtility.SetParentAndAlign(separator, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(separator, "Create " + separator.name);
        Selection.activeObject = separator;
    }
}
