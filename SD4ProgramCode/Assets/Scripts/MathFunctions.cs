//--------------------------------------------------------------------------------
// Script outputs the compile time to the console when project changes occur.
//--------------------------------------------------------------------------------

// Lists all the usings the MathFunctions script will need
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Creates the MathFunctions class, which only runs in Unity Editor
[ExecuteInEditMode]
public class MathFunctions : MonoBehaviour
{
    // Divides the section of variables into variables for the Clamp function
    [Header("Clamp Function")]

    // Toggles whether the Clamp function gets compiled or not
    public bool m_bClampFunction;

    // A parameter that lists the initial value being clamped down
    public float m_fClampValue;

    // A parameter that indicates the minimum range
    public float m_fClampMin;

    // A parameter that indicates the maximum range
    public float m_fClampMax;

    // Divides the section of variables into variables for the Approximately function
    [Header("Approximately Function")]

    // Toggles whether the Approximately function gets compiled or not
    public bool m_bApproximatelyFunction;

    // A parameter that lists the first number as a float
    public float m_fApproxA; 

    // A parameter that lists the second number as a float
    public float m_fApproxB;

    // Divides the section of variables into variables for the DeltaAngle function
    [Header("DeltaAngle Function")]

    // Toggles whether the DeltaAngle function gets compiled or not
    public bool m_bDeltaAngleFunction;

    // A parameter that indicates the current angle as a float
    public float m_fAngleCurrent;

    // A parameter that indicates the float target angle
    public float m_fAngleTarget;

    // Divides the section of variables into variables for the Lerp function
    [Header("Lerp Function")]

    // Toggles whether the Lerp function gets compiled or not
    public bool m_bLerpFunction;

    // A parameter that lists one of the Vector3s
    public Vector3 m_v3LerpVectorA;

    // A parameter for the other Vector3
    public Vector3 m_v3LerpVectorB;

    // A parameter that lists the rate of the lerp
    public float m_fLerpValue;

    // Divides the section of variables into variables for the LerpUnclamped function
    [Header("Lerp Unclamped Function")]

    // Toggles whether the LerpUnclamped function gets compiled or not
    public bool m_bLerpUnclampedFunction;

    // A parameter that lists one of the Vector3s
    public Vector3 m_v3ULerpVectorA;

    // A parameter for the other Vector3
    public Vector3 m_v3ULerpVectorB;

    // A parameter that lists the rate of the lerp as a float
    public float m_fULerpValue;

    // Divides the section of variables into variables for the MoveTowards function
    [Header("Move Towards Function")]

    // Toggles whether the MoveTowards function gets compiled or not
    public bool m_bMoveTowardsFunction;

    // A parameter that identifies the current Vector3 location
    public Vector3 m_v3MoveCurrent;

    // A parameter that highlights the Vector3 which will be moved towards
    public Vector3 m_v3MoveTarget;

    // A parameter that lists the rate of movement as a float
    public float m_fMoveValue;

    // Divides the section of variables into variables for the LookAt function
    [Header("Look At Function")]

    // Toggles whether the LookAt function gets compiled or not
    public bool m_bLookAtFunction;

    // A parameter inidcating the target as a Vector3
    public Vector3 m_v3LookAtTarget;

    // Divides the section of variables into variables for the SmoothDamp function
    [Header("Smooth Damp Function")]

    // Toggles whether the Damp function gets compiled or not
    public bool m_bSmoothDampFunction;

    // A parameter indicating the initial Vector3 value
    public Vector3 m_v3DampCurrent;

    // A parameter that indicates the target Vector3
    public Vector3 m_v3DampTarget;

    // A parameter for the velocity as a Vector3
    public Vector3 m_v3DampVelocity;

    // A float parameter that lists the rate of dampening
    public float m_fDampTime;

    // Divides the section of variables into variables for the Mathf Log function
    [Header("Log Function")]

    // Toggles whether the Mathf Log function gets compiled or not
    public bool m_bLogFunction;

    // A paramater highling the float base number
    public float m_fLogValue; 

    // A paramater indicating the power number in the equation as a float
    public float m_fLogPower;

    // Divides the section of variables into variables for the Random function
    [Header("Random Function")]

    // Toggles whether the Random function gets compiled or not
    public bool m_bRandomFunction;

    // A paramater of the minimum float value
    public float m_fRandomMin;

    // A paramater of the maximum float value
    public float m_fRandomMax;

    //--------------------------------------------------------------------------------
    // Function is called every frame and updates the scene when called.
    //--------------------------------------------------------------------------------
    private void Update() 
    {
        // Calls the Clamp function with its parameters if Clamp bool is true
        if (m_bClampFunction) 
        {
            Clamp(m_fClampValue, m_fClampMin, m_fClampMax);
        }

        // Calls the Approximately function with its parameters if the bool is true
        if (m_bApproximatelyFunction)
        {
            Approximately(m_fApproxA, m_fApproxB);
        }

        // Calls the DeltaAngle function with its parameters if the bool is true
        if (m_bDeltaAngleFunction)
        {
            DeltaAngle(m_fAngleCurrent, m_fAngleTarget); 
        }

        // Calls the Lerp function with its parameters if Lerp bool is true
        if (m_bLerpFunction)
        {
            Lerp(m_v3LerpVectorA, m_v3LerpVectorB, m_fLerpValue); 
        }

        // Calls the LerpUnclamped function with its parameters if that bool is true
        if (m_bLerpUnclampedFunction)
        {
            LerpUnclamped(m_v3ULerpVectorA, m_v3ULerpVectorB, m_fULerpValue); 
        }

        // Calls the MoveTowards function with its parameters if the bool is true
        if (m_bMoveTowardsFunction)
        {
            MoveTowards(m_v3MoveCurrent, m_v3MoveTarget, m_fMoveValue);   
        }

        // Calls the LookAt function with its parameters if LookAt bool is true
        if (m_bLookAtFunction)
        {
            LookAt(m_v3LookAtTarget);
        }

        // Calls the SmoothDamp function with its parameters if the bool is true
        if (m_bSmoothDampFunction)
        {
            SmoothDamp(m_v3DampCurrent, m_v3DampTarget, m_v3DampVelocity, m_fDampTime);  
        }

        // Calls the Log function with its parameters if Log bool is true
        if (m_bLogFunction)
        {
            Log(m_fLogValue, m_fLogPower); 
        }

        // Calls the Random function with its parameters if Random bool is true
        if (m_bRandomFunction)
        {
            Rand(m_fRandomMin, m_fRandomMax); 
        }
    }

    //--------------------------------------------------------------------------------
    // Function clamps a value down into a range of values.
    //
    // Param:
    //      fValue: A float indicating the Clamp value.
    //      fMin: A float that represents the minimum range number.
    //      fMax: A float for the maximum Clamp value.
    //--------------------------------------------------------------------------------
    private void Clamp(float fValue, float fMin, float fMax)
    {
        Mathf.Clamp(fValue, fMin, fMax);
    }

    //--------------------------------------------------------------------------------
    // Function estimates whether two floats are approximately the same value.
    //
    // Param:
    //      fApproxA: A float indicating the first value.
    //      fApproxB: A float indicating the second value.
    //--------------------------------------------------------------------------------
    private void Approximately(float fApproxA, float fApproxB)
    {
        Mathf.Approximately(fApproxA, fApproxB);
    }

    //--------------------------------------------------------------------------------
    // Function gives the angle between two delta float values.
    //
    // Param:
    //      fApproxA: A float for the current angle in pheta.
    //      fApproxB: A float representing the target angle.
    //--------------------------------------------------------------------------------
    private void DeltaAngle(float fAngleCurrent, float fAngleTarget)
    {
        Mathf.DeltaAngle(fAngleCurrent, fAngleTarget);
    }

    //--------------------------------------------------------------------------------
    // Function performs a lerp between two Vector3s.
    //
    // Param:
    //      v3LerpVectorA: A Vector3 for the initial vector.
    //      v3LerpVectorB: A Vector3 representing the target vector.
    //      fLerpValue: A float that indicates the rate of the lerp.
    //--------------------------------------------------------------------------------
    private void Lerp(Vector3 v3LerpVectorA, Vector3 v3LerpVectorB, float fLerpValue)
    {
        Vector3.Lerp(v3LerpVectorA, v3LerpVectorB, fLerpValue);
    }

    //--------------------------------------------------------------------------------
    // Function performs a lerp between two Vector3s and returns an unclamped value.
    //
    // Param:
    //      v3ULerpVectorA: A Vector3 for the initial vector.
    //      v3ULerpVectorB: A Vector3 representing the target vector.
    //      fULerpValue: A float that indicates the rate of the lerp.
    //--------------------------------------------------------------------------------
    private void LerpUnclamped(Vector3 v3ULerpVectorA, Vector3 v3ULerpVectorB, 
                               float fULerpValue)
    {
        Vector3.LerpUnclamped(v3ULerpVectorA, v3ULerpVectorB, fULerpValue);
    }

    //--------------------------------------------------------------------------------
    // Function moves a Vector3 towards a target at a linear rate.
    //
    // Param:
    //      v3MoveCurrent: A Vector3 indicating the current vector position.
    //      v3MoveTarget: A Vector3 that outlines the vector of the target.
    //      fMoveValue: A float for the rate of movement, usually deltaTime.
    //--------------------------------------------------------------------------------
    private void MoveTowards(Vector3 v3MoveCurrent, Vector3 v3MoveTarget, 
                             float fMoveValue)
    {
        Vector3.MoveTowards(v3MoveCurrent, v3MoveTarget, fMoveValue);
    }

    //--------------------------------------------------------------------------------
    // Function makes an object look at a certain Vector3 position.
    //
    // Param:
    //      v3LookAtTarget: A Vector3 for the target the object will look at.
    //--------------------------------------------------------------------------------
    private void LookAt(Vector3 v3LookAtTarget)
    {
        transform.LookAt(v3LookAtTarget);
    }

    //--------------------------------------------------------------------------------
    // Function performs a smooth damp movement between two vectors.
    //
    // Param:
    //      v3MoveCurrent: A Vector3 indicating the current vector position.
    //      v3MoveTarget: A Vector3 that outlines the vector of the target.
    //      v3DampVelocity: A Vector3 for the velocity that the dampening.
    //      fMoveValue: A float for the deltaTime variable to be included.
    //--------------------------------------------------------------------------------
    private void SmoothDamp(Vector3 v3DampCurrent, Vector3 v3DampTarget, 
                            Vector3 v3DampVelocity, float fDampTime)
    {
        Vector3.SmoothDamp(v3DampCurrent, v3DampTarget, ref v3DampVelocity, fDampTime);
    }

    //--------------------------------------------------------------------------------
    // Function calculates a logarithm, which is the opposite of an exponentiation.
    //
    // Param:
    //      fLogValue: A float for the base value.
    //      fLogPower: A float representing the power value in the equation.
    //--------------------------------------------------------------------------------
    private void Log(float fLogValue, float fLogPower)
    {
        Mathf.Log(fLogValue, fLogPower);
    }

    //--------------------------------------------------------------------------------
    // Function chooses a random number between a parameter defined range.
    //
    // Param:
    //      fMin: A float indicating the minimum value.
    //      fMax: A float indicating the maximum value.
    //--------------------------------------------------------------------------------
    private void Rand(float fMin, float fMax)
    {
        Random.Range(fMin, fMax);
    }  
}
