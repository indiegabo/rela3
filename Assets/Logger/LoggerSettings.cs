using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLoggerSettings", menuName = "Logger/LoggerSettings")]
public class LoggerSettings : ScriptableObject
{
    [SerializeField] private bool m_shouldLog = false;
    [SerializeField] private Color m_fallbackColor;
    [SerializeField] private Color m_successColor;
    [SerializeField] private Color m_errorColor;
    [SerializeField] private Color m_warningColor;
    public bool shouldLog => m_shouldLog;

    public Color fallbackColor => m_fallbackColor != null ? m_fallbackColor : new Color(38f, 0, 57f);
    public Color successColor => m_successColor != null ? m_successColor : fallbackColor;
    public Color errorColor => m_errorColor != null ? m_errorColor : fallbackColor;
    public Color warningColor => m_warningColor != null ? m_warningColor : fallbackColor;
}
