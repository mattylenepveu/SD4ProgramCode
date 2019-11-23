//--------------------------------------------------------------------------------
// Script outputs the compile time to the console when project changes occur.
//--------------------------------------------------------------------------------

// Lists all the usings the CompileTime script will need
using UnityEngine;
using UnityEditor;

// Creates the CompileTime class, which only runs in Unity Editor
[ExecuteInEditMode] 
public class CompileTime : MonoBehaviour
{
    // Records the time that the program started compiling as a double
    private double m_dCompileStartTime;

    // Stores the total compile time as a double
    private double m_dFinalCompileTime;

    // Bool indicates whether the program is compiling or not 
    private bool m_bIsCompiling = false;

    //--------------------------------------------------------------------------------
    // Function is called every frame and updates the scene when called.
    //--------------------------------------------------------------------------------
    private void Update()
    {
        // Checks if compiling bool is true
        if (m_bIsCompiling)
        {
            // Detects if the editor application has stopped compiling
            if (!EditorApplication.isCompiling)
            {
                // Lets the script know the editor application has finished compiling
                m_bIsCompiling = false;

                // Calls and runs the CompileFinished function
                CompileFinished();
            }
        }
        // Else if the compiling bool is false
        else
        {
            // Detects if the editor application has began compiling
            if (EditorApplication.isCompiling)
            {
                // Informs the script that the editor is now compiling
                m_bIsCompiling = true;

                // Calls and runs the CompileFinished function
                CompileStarted();
            }
        }
    }

    //--------------------------------------------------------------------------------
    // Function begins recording the compile time of the Editor.
    //--------------------------------------------------------------------------------
    private void CompileStarted()
    {  
        // Logs to the debug console that the compiler has started compiling
        Debug.Log("Compile started...");

        // Receives the time since editor began compiling the frame the editor compiles
        m_dCompileStartTime = EditorApplication.timeSinceStartup;
    }

    //--------------------------------------------------------------------------------
    // Function stops and calculates the compile time for the Editor.
    //--------------------------------------------------------------------------------
    private void CompileFinished()
    {
        // Calculates the final compile time on the frame the editor stops compiling
        m_dFinalCompileTime = EditorApplication.timeSinceStartup - m_dCompileStartTime;

        // Logs the compile time to debug console, rounding to two decimal places
        Debug.Log("Compile Finished: " + m_dFinalCompileTime.ToString("F2") + "s");
    }
} 
