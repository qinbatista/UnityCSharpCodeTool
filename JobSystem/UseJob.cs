using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class UseJob : MonoBehaviour
{
    NativeArray<bool> _activeList;
    public TransformAccessArray _transformAccessArray;
    SpellStateJob _spellJobParallel;
    JobHandle _jobHandle;
    void Awake()
    {
        _activeList = new NativeArray<float>(MonsterBuilder.Instance.MonsterListSize, Allocator.Persistent);
        _transformAccessArray = new TransformAccessArray(10);
    }
    void Update()
    {
        _spellJobParallel = new SpellStateJob()
        {
            position = this.transform.position,
            activeList = _monsterPrefabList._activeList
        };
        _jobHandle = _spellJobParallel.Schedule(_monsterPrefabList._transformAccessArray);
        _jobHandle.Complete();
        foreach (bool isAttacked in _attackedMonsterList)
        {
            if (isAttacked)
            {
                print("Attacked=" + _spellAttackedCount);
            }
        }
    }
    void OnDestroy()
    {
        _activeList.Dispose();
        _transformAccessArray.Dispose();
    }
}
