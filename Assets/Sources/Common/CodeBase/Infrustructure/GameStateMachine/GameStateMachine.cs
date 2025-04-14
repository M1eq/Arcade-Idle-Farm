using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : IGameStateMachine, IInitializable
{
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    private readonly StateFactory _stateFactory;

    public GameStateMachine(StateFactory stateFactory)
    {
        _stateFactory = stateFactory;
    }

    public void Initialize()
    {
        _states = new Dictionary<Type, IExitableState>()
        {
            [typeof(BootstrapState)] = _stateFactory.CreateState<BootstrapState>(),
        };

        Enter<BootstrapState>();
    }

    public void Enter<TState>() where TState : class, IState
    {
        var state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
        var state = ChangeState<TState>();
        state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();

        var state = GetState<TState>();
        _activeState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
        _states[typeof(TState)] as TState;
}
