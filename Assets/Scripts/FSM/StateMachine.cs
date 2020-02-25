using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class StateMachine<T> where T : MonoBehaviour
    {
        private IState<T> _state;
        private T _owner;
        private Dictionary<Type, IState<T>> _statesDictionary = new Dictionary<Type, IState<T>>();

        public StateMachine(T owner)
        {
            _owner = owner;
        }

        public void Update()
        {
            _state?.Execute(this, _owner);
        }

        public void ChangeState(Type type)
        {
            _state?.Exit(this, _owner);
            if (_statesDictionary.ContainsKey(type))
            {
                _state = _statesDictionary[type];
            }
            else
            {
                var newState = (IState<T>)Activator.CreateInstance(type);
                _statesDictionary.Add(type, newState);
                _state = newState;
            }
            _state?.Enter(this, _owner);
        }
    } 
}
