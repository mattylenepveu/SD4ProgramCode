using UnityEngine;
using UnityEditor;

[ExecuteInEditMode] 
public class CompileTime : MonoBehaviour
{
    private double m_dCompileStartTime;
    private double m_dFinalCompileTime;

    private bool m_bIsCompiling = false;

    private void Update()
    {
        if (m_bIsCompiling)
        {
            if (!EditorApplication.isCompiling)
            {
                m_bIsCompiling = false;
                CompileFinished();
            }
        }
        else
        {
            if (EditorApplication.isCompiling)
            {
                m_bIsCompiling = true;
                CompileStarted();
            }
        }
    }

    private void CompileStarted()
    {  
        Debug.Log("Compile started...");
        m_dCompileStartTime = EditorApplication.timeSinceStartup;
    }

    private void CompileFinished()
    {
        m_dFinalCompileTime = EditorApplication.timeSinceStartup - m_dCompileStartTime;
        Debug.Log("Compile Finished: " + m_dFinalCompileTime.ToString("F2") + "s");
    }
} 
