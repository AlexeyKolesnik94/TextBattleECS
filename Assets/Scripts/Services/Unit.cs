using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Leopotam.Ecs;
using UnityEngine;

public class Unit : MonoBehaviour, IEntity
{
    public EcsEntity Entity
    {
        get => _ecsEntity;
        set => _ecsEntity = value;
    }
    private EcsEntity _ecsEntity;

    private void OnMouseDown()
    {
        _ecsEntity.Get<ClickEvent>();
    }
}

public interface IEntity
{
    EcsEntity Entity { get; set; }
}
