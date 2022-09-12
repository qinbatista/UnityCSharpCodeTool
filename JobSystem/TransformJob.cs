using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;
using UnityEngine.Jobs;

[BurstCompile]
public struct TransformJob : IJobParallelForTransform
{
    [ReadOnly] public Vector3 position;
    public NativeArray<bool> activeList;
    public void Execute(int index, TransformAccess transform)
    {
        if(spellPosition>0)activeList[index] = true;
        else activeList[index] = false;
    }
}