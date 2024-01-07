using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : NetworkBehaviour, IDamageable
{
    private Dictionary<PlayerStateType, PlayerState> states;
    [field: SerializeField]
    public PlayerStateType CurrentState { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerAnimation Anim { get; private set; }
    public PlayerRagdoll Ragdoll { get; private set; }
    public PlayerView View { get; private set; }
    public PlayerAttack Attack { get; private set; }
    [field:SerializeField]
    public InputReader InputReader { get; private set; }

    private void Awake()
    {
        states = new();
        Movement = GetComponent<PlayerMovement>();
        Anim = transform.Find("Visual").GetComponent<PlayerAnimation>();
        Ragdoll = GetComponent<PlayerRagdoll>();
        View = GetComponent<PlayerView>();
        Attack = GetComponent<PlayerAttack>();

        Movement.InitCompo(this);
        Anim.InitCompo(this);
        Ragdoll.InitCompo(this);
        View.InitCompo(this);
        Attack.InitCompo(this);

        InitState();
    }

    private void Update()
    {
        if (!IsOwner)
            return;

        Movement.UpdateCompo();
        Anim.UpdateCompo();
        Ragdoll.UpdateCompo();
        View.UpdateCompo();
        Attack.UpdateCompo();
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

    public void OnDamaged(int damage = 0, GameObject performer = null, Vector3 point = default)
    {
        Debug.Log(gameObject.name);
        ChangeStateClientRpc(PlayerStateType.Stun);
    }
}
