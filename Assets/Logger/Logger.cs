using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public static Logger Instance;
    public static string SuccessType = "SUCCESS";
    public static string WarningType = "WARNING";
    public static string ErrorType = "ERROR";

    [SerializeField] LoggerSettings settings;

    protected virtual void Awake()
    {
        Instance = this;
    }

    public void Success(string message, Object sender = null)
    {
        if (!settings.shouldLog) return;
        string color = "#" + ColorUtility.ToHtmlStringRGB(settings.successColor);
        Log(SuccessType, message, color, sender);
    }
    public void Warning(string message, Object sender = null)
    {
        if (!settings.shouldLog) return;
        string color = "#" + ColorUtility.ToHtmlStringRGB(settings.warningColor);
        Log(WarningType, message, color, sender);
    }
    public void Error(string message, Object sender = null)
    {
        if (!settings.shouldLog) return;
        string color = "#" + ColorUtility.ToHtmlStringRGB(settings.errorColor);
        Log(ErrorType, message, color, sender);
    }

    protected virtual void Log(string type, string message, string color, Object sender = null)
    {
        if (sender != null)
        {
            Debug.Log($"<color={color}> {type} </color> {message}", sender);

        }
        else
        {
            Debug.Log($"<color={color}> {type} </color> {message}");
        }
    }
}
