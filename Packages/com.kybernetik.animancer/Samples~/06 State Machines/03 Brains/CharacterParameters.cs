// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2025 Kybernetik //

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value.

using System;
using UnityEngine;

namespace Animancer.Samples.StateMachines
{
    /// <summary>The parameters that control a <see cref="Character"/>.</summary>
    /// 
    /// <remarks>
    /// <strong>Sample:</strong>
    /// <see href="https://kybernetik.com.au/animancer/docs/samples/fsm/brains">
    /// Brains</see>
    /// </remarks>
    /// 
    /// https://kybernetik.com.au/animancer/api/Animancer.Samples.StateMachines/CharacterParameters
    /// 
    [Serializable]
    public class CharacterParameters
    {
        /************************************************************************************************************************/

        [SerializeField]
        private Vector3 _MovementDirection;
        public Vector3 MovementDirection
        {
            get => _MovementDirection;
            set => _MovementDirection = Vector3.ClampMagnitude(value, 1);
        }

        /************************************************************************************************************************/

        [SerializeField]
        private bool _WantsToRun;
        public ref bool WantsToRun => ref _WantsToRun;

        /************************************************************************************************************************/
    }
}
