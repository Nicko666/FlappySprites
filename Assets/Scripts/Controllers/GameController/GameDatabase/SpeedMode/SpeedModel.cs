using System;
using UnityEngine;

[Serializable]
internal class SpeedModel
{
    [field: SerializeField] internal float ArithmeticAccelerator { get; private set; } = 0.001f;
    [field: SerializeField] internal float GeometricAccelerator { get; private set; } = 1f;
    [field: SerializeField] internal float MaxTimeScale { get; private set; } = 10;
}