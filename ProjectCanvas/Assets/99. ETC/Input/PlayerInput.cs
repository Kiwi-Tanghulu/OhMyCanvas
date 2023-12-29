//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/99. ETC/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Play"",
            ""id"": ""71892a40-03e3-42e3-9f06-45feb585d855"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""dae63f02-a1b2-4609-8a44-1a57de8e7f77"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c9f158e3-5b1a-4f38-94a3-e334356174a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""398059a4-284b-4d74-af58-6a6c95afce3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""281a39fc-8ae0-4495-b431-bbd1dd8e0228"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""94084765-39f1-4ce3-b5e6-2116981606c7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7799ca67-7955-4811-b173-150a61a87f19"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""de601298-8396-43c5-9fa7-cfc91eb9ebf8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""44c948d3-a105-4b1a-9610-cbfdc36d3933"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""85780f3c-5b71-4ded-9873-9df408fc05b9"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c095b96-53f1-4574-b13b-91cbecd09233"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard"",
            ""bindingGroup"": ""keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Play
        m_Play = asset.FindActionMap("Play", throwIfNotFound: true);
        m_Play_Move = m_Play.FindAction("Move", throwIfNotFound: true);
        m_Play_Interact = m_Play.FindAction("Interact", throwIfNotFound: true);
        m_Play_MouseMove = m_Play.FindAction("MouseMove", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Play
    private readonly InputActionMap m_Play;
    private List<IPlayActions> m_PlayActionsCallbackInterfaces = new List<IPlayActions>();
    private readonly InputAction m_Play_Move;
    private readonly InputAction m_Play_Interact;
    private readonly InputAction m_Play_MouseMove;
    public struct PlayActions
    {
        private @PlayerInput m_Wrapper;
        public PlayActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Play_Move;
        public InputAction @Interact => m_Wrapper.m_Play_Interact;
        public InputAction @MouseMove => m_Wrapper.m_Play_MouseMove;
        public InputActionMap Get() { return m_Wrapper.m_Play; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayActions set) { return set.Get(); }
        public void AddCallbacks(IPlayActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @MouseMove.started += instance.OnMouseMove;
            @MouseMove.performed += instance.OnMouseMove;
            @MouseMove.canceled += instance.OnMouseMove;
        }

        private void UnregisterCallbacks(IPlayActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @MouseMove.started -= instance.OnMouseMove;
            @MouseMove.performed -= instance.OnMouseMove;
            @MouseMove.canceled -= instance.OnMouseMove;
        }

        public void RemoveCallbacks(IPlayActions instance)
        {
            if (m_Wrapper.m_PlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayActions @Play => new PlayActions(this);
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get
        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.FindControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
    public interface IPlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
    }
}
