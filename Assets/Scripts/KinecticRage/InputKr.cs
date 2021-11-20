// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/KinecticRage/InputKr.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputKr : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputKr()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputKr"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""611d157c-9183-4257-a26f-5e1b3ed57db8"",
            ""actions"": [
                {
                    ""name"": ""2D"",
                    ""type"": ""Button"",
                    ""id"": ""78b58965-291e-4115-94e5-5265d0a99a19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""dbc8d7a9-ac1a-4677-8c48-3dca6b0bab68"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2D"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""46d20568-03ac-42da-90d8-8defd849fcfe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""97cfa24b-d7ee-4339-aaa6-53a4417d627b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player__2D = m_Player.FindAction("2D", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player__2D;
    public struct PlayerActions
    {
        private @InputKr m_Wrapper;
        public PlayerActions(@InputKr wrapper) { m_Wrapper = wrapper; }
        public InputAction @_2D => m_Wrapper.m_Player__2D;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @_2D.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_2D;
                @_2D.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_2D;
                @_2D.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_2D;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @_2D.started += instance.On_2D;
                @_2D.performed += instance.On_2D;
                @_2D.canceled += instance.On_2D;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void On_2D(InputAction.CallbackContext context);
    }
}
