using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Logger : MonoBehaviour
{

    [SerializeField] protected LoggerSettings m_settings;

    protected string successHEX => "#" + ColorUtility.ToHtmlStringRGB(m_settings.successColor);
    protected string dangerHEX => "#" + ColorUtility.ToHtmlStringRGB(m_settings.dangerColor);
    protected string warningHEX => "#" + ColorUtility.ToHtmlStringRGB(m_settings.warningColor);


    protected virtual void Log(string message, string color, Object sender = null)
    {
        if (sender != null)
        {
            Debug.Log($"<color={color}> {message} </color>", sender);

        }
        else
        {
            Debug.Log($"<color={color}> {message} </color>");
        }
    }
}