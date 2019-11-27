using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class MathFunctions : MonoBehaviour
{
    [Header("Clamp Function")]
    public bool m_bClampFunction;

    public float m_fClampValue;

    public float m_fClampMin;

    public float m_fClampMax;

    [Header("Approximately Function")]
    public bool m_bApproximatelyFunction;

    public float m_fApproxA; 

    public float m_fApproxB;

    [Header("DeltaAngle Function")]
    public bool m_bDeltaAngleFunction;

    public float m_fAngleCurrent;

    public float m_fAngleTarget;

    [Header("Lerp Function")]
    public bool m_bLerpFunction;

    public Vector3 m_v3LerpVectorA;

    public Vector3 m_v3LerpVectorB;

    public float m_fLerpValue;

    [Header("Lerp Unclamped Function")]
    public bool m_bLerpUnclampedFunction;

    public Vector3 m_v3ULerpVectorA;

    public Vector3 m_v3ULerpVectorB;

    public float m_fULerpValue;

    [Header("Move Towards Function")]
    public bool m_bMoveTowardsFunction;

    public Vector3 m_v3MoveCurrent;

    public Vector3 m_v3MoveTarget;

    public float m_fMoveValue;

    [Header("Look At Function")]
    public bool m_bLookAtFunction;

    public Vector3 m_v3LookAtTarget;

    [Header("Smooth Damp Function")]
    public bool m_bSmoothDampFunction;

    public Vector3 m_v3DampCurrent;

    public Vector3 m_v3DampTarget;

    public Vector3 m_v3DampVelocity;

    public float m_fDampTime;

    [Header("Log Function")]
    public bool m_bLogFunction;

    public float m_fLogValue; 

    public float m_fLogPower; 

    [Header("Random Function")]
    public bool m_bRandomFunction;

    public float m_fRandomMin;

    public float m_fRandomMax;  

    // Update is called once per frame
    void Update() 
    {
        if (m_bClampFunction) 
        {
            Clamp(m_fClampValue, m_fClampMin, m_fClampMax);
        }

        if (m_bApproximatelyFunction)
        {
            Approximately(m_fApproxA, m_fApproxB);
        }

        if (m_bDeltaAngleFunction)
        {
            DeltaAngle(m_fAngleCurrent, m_fAngleTarget); 
        }

        if (m_bLerpFunction)
        {
            Lerp(m_v3LerpVectorA, m_v3LerpVectorB, m_fLerpValue); 
        }

        if (m_bLerpUnclampedFunction)
        {
            LerpUnclamped(m_v3ULerpVectorA, m_v3ULerpVectorB, m_fULerpValue); 
        }

        if (m_bMoveTowardsFunction)
        {
            MoveTowards(m_v3MoveCurrent, m_v3MoveTarget, m_fMoveValue);   
        }

        if (m_bLookAtFunction)
        {
            LookAt(m_v3LookAtTarget);
        }

        if (m_bSmoothDampFunction)
        {
            SmoothDamp(m_v3DampCurrent, m_v3DampTarget, m_v3DampVelocity, m_fDampTime);  
        }

        if (m_bLogFunction)
        {
            Log(m_fLogValue, m_fLogPower); 
        }

        if (m_bRandomFunction)
        {
            Rand(m_fRandomMin, m_fRandomMax); 
        }
    }

    private void Clamp(float fValue, float fMin, float fMax)
    {
        Mathf.Clamp(fValue, fMin, fMax);
    }

    private void Approximately(float fApproxA, float fApproxB)
    {
        Mathf.Approximately(fApproxA, fApproxB);
    }

    private void DeltaAngle(float fAngleCurrent, float fAngleTarget)
    {
        Mathf.DeltaAngle(fAngleCurrent, fAngleTarget);
    }

    private void Lerp(Vector3 v3LerpVectorA, Vector3 v3LerpVectorB, float fLerpValue)
    {
        Vector3.Lerp(v3LerpVectorA, v3LerpVectorB, fLerpValue);
    }

    private void LerpUnclamped(Vector3 v3ULerpVectorA, Vector3 v3ULerpVectorB, float fULerpValue)
    {
        Vector3.LerpUnclamped(v3ULerpVectorA, v3ULerpVectorB, fULerpValue);
    }

    private void MoveTowards(Vector3 v3MoveCurrent, Vector3 v3MoveTarget, float fMoveValue)
    {
        Vector3.MoveTowards(v3MoveCurrent, v3MoveTarget, fMoveValue);
    }

    private void LookAt(Vector3 v3LookAtTarget)
    {
        transform.LookAt(v3LookAtTarget);
    }
     
    private void SmoothDamp(Vector3 v3DampCurrent, Vector3 v3DampTarget, Vector3 v3DampVelocity, float fDampTime)
    {
        Vector3.SmoothDamp(v3DampCurrent, v3DampTarget, ref v3DampVelocity, fDampTime);
    }

    private void Log(float fLogValue, float fLogPower)
    {
        Mathf.Log(fLogValue, fLogPower);
    }

    private void Rand(float fMin, float fMax)
    {
        Random.Range(fMin, fMax);
    }  
}
