using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Logger : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] protected bool m_shouldLog = true;

    [Header("Colors")]
    [SerializeField] protected Color m_successColor = new Color(60f, 255f, 146f); // Light Green
    [SerializeField] protected Color m_warningColor = new Color(255f, 247f, 60f); // Light Yellow
    [SerializeField] protected Color m_dangerColor = new Color(255f, 60f, 60f); // Light Red

    protected string successHEX => "#" + ColorUtility.ToHtmlStringRGB(m_successColor);
    protected string warningHEX => "#" + ColorUtility.ToHtmlStringRGB(m_warningColor);
    protected string dangerHEX => "#" + ColorUtility.ToHtmlStringRGB(m_dangerColor);
    protected string whiteHEX => "#FFFFFF";


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