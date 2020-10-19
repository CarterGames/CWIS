// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CarterGames.CWIS
{
    public class @Actions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Actions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Weapons"",
            ""id"": ""575874f3-b466-4904-b9a3-620d3c88d902"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e23ddf8b-0172-4ccf-9a7f-e928c946ce3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8b8acc8d-ad21-4e69-82f1-efba3b8ed2f4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
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
        },
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Weapons
            m_Weapons = asset.FindActionMap("Weapons", throwIfNotFound: true);
            m_Weapons_Fire = m_Weapons.FindAction("Fire", throwIfNotFound: true);
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

        // Weapons
        private readonly InputActionMap m_Weapons;
        private IWeaponsActions m_WeaponsActionsCallbackInterface;
        private readonly InputAction m_Weapons_Fire;
        public struct WeaponsActions
        {
            private @Actions m_Wrapper;
            public WeaponsActions(@Actions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Fire => m_Wrapper.m_Weapons_Fire;
            public InputActionMap Get() { return m_Wrapper.m_Weapons; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WeaponsActions set) { return set.Get(); }
            public void SetCallbacks(IWeaponsActions instance)
            {
                if (m_Wrapper.m_WeaponsActionsCallbackInterface != null)
                {
                    @Fire.started -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnFire;
                }
                m_Wrapper.m_WeaponsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                }
            }
        }
        public WeaponsActions @Weapons => new WeaponsActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        private int m_MobileSchemeIndex = -1;
        public InputControlScheme MobileScheme
        {
            get
            {
                if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
                return asset.controlSchemes[m_MobileSchemeIndex];
            }
        }
        public interface IWeaponsActions
        {
            void OnFire(InputAction.CallbackContext context);
        }
    }
}
