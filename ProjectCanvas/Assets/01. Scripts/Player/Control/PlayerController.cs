using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private Dictionary<PlayerStateType, PlayerState> states;
    [field: SerializeField]
    public PlayerStateType CurrentState { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerAnimation Anim { get; private set; }
    public PlayerRagdoll Ragdoll { get; private set; }
    public PlayerView View { get; private set; }
    [field:SerializeField]
    public InputReader InputReader { get; private set; }

    private void Awake()
    {
        states = new();
        Movement = GetComponent<PlayerMovement>();
        Anim = GetComponent<PlayerAnimation>();
        Ragdoll = GetComponent<PlayerRagdoll>();
        View = GetComponent<PlayerView>();

        Movement.InitCompo(this);
        Anim.InitCompo(this);
        Ragdoll.InitCompo(this);
        View.InitCompo(this);
        InitState();
    }

    private void Update()
    {
        Movement.UpdateCompo();
        Anim.UpdateCompo();
        Ragdoll.UpdateCompo();
        View.UpdateCompo();
        states[CurrentState].UpdateState();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        ChangeState(PlayerStateType.Idle);
    }

    #region ChangeState
    public void ChangeState(PlayerStateType type)
    {
        if (!IsOwner)
            return;

        ChangeStateServerRpc(type);
    }

    [ServerRpc]
    private void ChangeStateServerRpc(PlayerStateType type)
    {
        ChangeStateClientRpc(type);
    }

    [ClientRpc]
    private void ChangeStateClientRpc(PlayerStateType type)
    {
        if (states.TryGetValue(type, out PlayerState state))
        {
            if (state == null)
                return;
        }

        states[CurrentState]?.ExitState();
        CurrentState = type;
        states[CurrentState].EnterState();
    }
    #endregion

    private void InitState()
    {
        Transform stateContainer = transform.Find("StateContainer");

        foreach(PlayerStateType type in Enum.GetValues(typeof(PlayerStateType)))
        {
            string stateName = $"Player{type}State";
            Transform stateTrm = stateContainer.Find(stateName);
            PlayerState state = (PlayerState)stateTrm?.GetComponent(stateName);

            if(state == null || stateTrm == null)
            {
                Debug.LogError($"Player{type}State¾øÀ½");
                continue;
            }

            state.InitState(this, type);
            states.Add(type, state);
        }
    }
}
