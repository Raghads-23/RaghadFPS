// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2025 Kybernetik //

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value.

using Animancer.Units;
using UnityEngine;

namespace Animancer.Samples.AnimatorControllers.GameKit
{
    /// <summary>A <see cref="CharacterState"/> which plays a series of "attack" animations.</summary>
    /// 
    /// <remarks>
    /// <strong>Sample:</strong>
    /// <see href="https://kybernetik.com.au/animancer/docs/samples/animator-controllers/3d-game-kit/attack">
    /// 3D Game Kit/Attack</see>
    /// </remarks>
    /// 
    /// https://kybernetik.com.au/animancer/api/Animancer.Samples.AnimatorControllers.GameKit/AttackState
    /// 
    [AddComponentMenu(Strings.SamplesMenuPrefix + "Game Kit - Attack State")]
    [AnimancerHelpUrl(typeof(AttackState))]
    public class AttackState : CharacterState
    {
        /************************************************************************************************************************/

        [SerializeField, DegreesPerSecond] private float _TurnSpeed = 400;
        [SerializeField] private UnityEvent _SetWeaponOwner;// See the Read Me.
        [SerializeField] private UnityEvent _OnStart;// See the Read Me.
        [SerializeField] private UnityEvent _OnEnd;// See the Read Me.
        [SerializeField] private ClipTransition[] _Animations;

        private int _CurrentAnimationIndex = int.MaxValue;
        private ClipTransition _CurrentAnimation;

        /************************************************************************************************************************/

        protected virtual void Awake()
        {
            _SetWeaponOwner.Invoke();
        }

        /************************************************************************************************************************/

        public override bool CanEnterState => Character.Movement.IsGrounded;

        /************************************************************************************************************************/

        /// <summary>
        /// Start at the beginning of the sequence by default, but if the previous attack hasn't faded out yet then
        /// perform the next attack instead.
        /// </summary>
        protected virtual void OnEnable()
        {
            if (_CurrentAnimationIndex >= _Animations.Length - 1 ||
                _Animations[_CurrentAnimationIndex].State.Weight == 0)
            {
                _CurrentAnimationIndex = 0;
            }
            else
            {
                _CurrentAnimationIndex++;
            }

            _CurrentAnimation = _Animations[_CurrentAnimationIndex];
            Character.Animancer.Play(_CurrentAnimation);
            Character.Parameters.ForwardSpeed = 0;
            _OnStart.Invoke();
        }

        /************************************************************************************************************************/

        protected virtual void OnDisable()
        {
            _OnEnd.Invoke();
        }

        /************************************************************************************************************************/

        public override bool FullMovementControl => false;

        /************************************************************************************************************************/

        protected virtual void FixedUpdate()
        {
            if (Character.CheckMotionState())
                return;

            Character.Movement.TurnTowards(Character.Parameters.MovementDirection, _TurnSpeed);
        }

        /************************************************************************************************************************/

        // Use the End Event time to determine when this state is alowed to exit.

        // We cannot simply have this method return false and set the End Event to call Character.CheckMotionState
        // because it uses TrySetState (instead of ForceSetState) which would be prevented if this returned false.

        // And we cannot have this method return true because that would allow other actions like jumping in the
        // middle of an attack.

        public override bool CanExitState
            => _CurrentAnimation.State.NormalizedTime >= _CurrentAnimation.State.NormalizedEndTime;

        /************************************************************************************************************************/
    }
}
