using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLoggerSettings", menuName = "Logger/Settings")]
public class LoggerSettings : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] protected bool m_shouldLog = true;

    [Header("Colors")]
    [SerializeField] protected Color m_successColor = new Color(60f, 255f, 146f); // Light Green
    [SerializeField] protected Color m_warningColor = new Color(255f, 247f, 60f); // Light Yellow
    [SerializeField] protected Color m_dangerColor = new Color(255f, 60f, 60f); // Light Red

    public bool shouldLog => m_shouldLog;
    public Color successColor => m_successColor;
    public Color warningColor => m_warningColor;
    public Color dangerColor => m_dangerColor;
}
