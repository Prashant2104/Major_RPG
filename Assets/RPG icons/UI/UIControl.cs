// GENERATED AUTOMATICALLY FROM 'Assets/RPG icons/UI/UIControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UIControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UIControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UIControl"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""0e285485-5561-4cd2-9169-737854d9b4b3"",
            ""actions"": [
                {
                    ""name"": ""Stats"",
                    ""type"": ""Button"",
                    ""id"": ""7412c3da-c7c9-41ff-8e31-78994e3a3dfd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3afc0af5-72b5-4b97-b407-b28808635030"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stats"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb528292-f760-4cad-90df-3e0d1cd2c493"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stats"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Stats = m_General.FindAction("Stats", throwIfNotFound: true);
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

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Stats;
    public struct GeneralActions
    {
        private @UIControl m_Wrapper;
        public GeneralActions(@UIControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Stats => m_Wrapper.m_General_Stats;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Stats.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnStats;
                @Stats.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnStats;
                @Stats.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnStats;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Stats.started += instance.OnStats;
                @Stats.performed += instance.OnStats;
                @Stats.canceled += instance.OnStats;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    public interface IGeneralActions
    {
        void OnStats(InputAction.CallbackContext context);
    }
}
