// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Barco.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Barco : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Barco()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Barco"",
    ""maps"": [
        {
            ""name"": ""Boat"",
            ""id"": ""7ced6f03-1aee-4643-9ac2-f9a8d6481135"",
            ""actions"": [
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""3aebf913-e500-4858-a77d-e6552f4a2973"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""b77db770-5d9e-4fd8-b093-165380a53cb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5a633b3a-b04b-4abd-b0b4-f84a11d6db16"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Tap(duration=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""047c7728-eb1b-4494-896b-c4f5d890358a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Boat
        m_Boat = asset.FindActionMap("Boat", throwIfNotFound: true);
        m_Boat_Action = m_Boat.FindAction("Action", throwIfNotFound: true);
        m_Boat_Dodge = m_Boat.FindAction("Dodge", throwIfNotFound: true);
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

    // Boat
    private readonly InputActionMap m_Boat;
    private IBoatActions m_BoatActionsCallbackInterface;
    private readonly InputAction m_Boat_Action;
    private readonly InputAction m_Boat_Dodge;
    public struct BoatActions
    {
        private @Barco m_Wrapper;
        public BoatActions(@Barco wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action => m_Wrapper.m_Boat_Action;
        public InputAction @Dodge => m_Wrapper.m_Boat_Dodge;
        public InputActionMap Get() { return m_Wrapper.m_Boat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoatActions set) { return set.Get(); }
        public void SetCallbacks(IBoatActions instance)
        {
            if (m_Wrapper.m_BoatActionsCallbackInterface != null)
            {
                @Action.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnAction;
                @Dodge.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnDodge;
            }
            m_Wrapper.m_BoatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
            }
        }
    }
    public BoatActions @Boat => new BoatActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IBoatActions
    {
        void OnAction(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
    }
}
