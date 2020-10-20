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
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
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
        },
        {
            ""name"": ""CIC"",
            ""id"": ""8bc92a5c-c640-487f-b327-100491183ff8"",
            ""actions"": [
                {
                    ""name"": ""ToggleWeaponOne"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5724e317-5ca4-4f18-ab09-459957b25e82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""ToggleWeaponTwo"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d7b3f88b-6ca2-485e-b812-05cb22eaae99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""ToggleWeaponThree"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c1c85238-d7b3-4224-8387-df7a4fd62145"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""ToggleWeaponFour"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3a68933c-e765-4528-ae4f-c51f64e4263d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""ToggleWeaponFive"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c6e0ffaf-4d38-4b62-ab53-9916994cbffb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""ToggleWeaponSix"",
                    ""type"": ""PassThrough"",
                    ""id"": ""461d099b-ac1f-48f1-b273-f5a88aec0959"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""591452a2-8313-400e-83e9-a07d69a90a80"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponSix"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e5043c2-6461-41cb-8426-73ee091ce2fa"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97318e8e-8b3b-4ae4-aa7c-13ff82b33c54"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""608f40f4-267d-42a9-b4c9-304390332c31"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b77a341e-6353-4f46-bbda-2c37aa9265d2"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponFour"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a932e725-2c24-459e-80b5-0611157921ce"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponFive"",
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
            // CIC
            m_CIC = asset.FindActionMap("CIC", throwIfNotFound: true);
            m_CIC_ToggleWeaponOne = m_CIC.FindAction("ToggleWeaponOne", throwIfNotFound: true);
            m_CIC_ToggleWeaponTwo = m_CIC.FindAction("ToggleWeaponTwo", throwIfNotFound: true);
            m_CIC_ToggleWeaponThree = m_CIC.FindAction("ToggleWeaponThree", throwIfNotFound: true);
            m_CIC_ToggleWeaponFour = m_CIC.FindAction("ToggleWeaponFour", throwIfNotFound: true);
            m_CIC_ToggleWeaponFive = m_CIC.FindAction("ToggleWeaponFive", throwIfNotFound: true);
            m_CIC_ToggleWeaponSix = m_CIC.FindAction("ToggleWeaponSix", throwIfNotFound: true);
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

        // CIC
        private readonly InputActionMap m_CIC;
        private ICICActions m_CICActionsCallbackInterface;
        private readonly InputAction m_CIC_ToggleWeaponOne;
        private readonly InputAction m_CIC_ToggleWeaponTwo;
        private readonly InputAction m_CIC_ToggleWeaponThree;
        private readonly InputAction m_CIC_ToggleWeaponFour;
        private readonly InputAction m_CIC_ToggleWeaponFive;
        private readonly InputAction m_CIC_ToggleWeaponSix;
        public struct CICActions
        {
            private @Actions m_Wrapper;
            public CICActions(@Actions wrapper) { m_Wrapper = wrapper; }
            public InputAction @ToggleWeaponOne => m_Wrapper.m_CIC_ToggleWeaponOne;
            public InputAction @ToggleWeaponTwo => m_Wrapper.m_CIC_ToggleWeaponTwo;
            public InputAction @ToggleWeaponThree => m_Wrapper.m_CIC_ToggleWeaponThree;
            public InputAction @ToggleWeaponFour => m_Wrapper.m_CIC_ToggleWeaponFour;
            public InputAction @ToggleWeaponFive => m_Wrapper.m_CIC_ToggleWeaponFive;
            public InputAction @ToggleWeaponSix => m_Wrapper.m_CIC_ToggleWeaponSix;
            public InputActionMap Get() { return m_Wrapper.m_CIC; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CICActions set) { return set.Get(); }
            public void SetCallbacks(ICICActions instance)
            {
                if (m_Wrapper.m_CICActionsCallbackInterface != null)
                {
                    @ToggleWeaponOne.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponOne;
                    @ToggleWeaponOne.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponOne;
                    @ToggleWeaponOne.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponOne;
                    @ToggleWeaponTwo.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponTwo;
                    @ToggleWeaponThree.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponThree;
                    @ToggleWeaponThree.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponThree;
                    @ToggleWeaponThree.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponThree;
                    @ToggleWeaponFour.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponFour;
                    @ToggleWeaponFour.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponFour;
                    @ToggleWeaponFour.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponFour;
                    @ToggleWeaponFive.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponFive;
                    @ToggleWeaponFive.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponFive;
                    @ToggleWeaponFive.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponFive;
                    @ToggleWeaponSix.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponSix;
                    @ToggleWeaponSix.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponSix;
                    @ToggleWeaponSix.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponSix;
                }
                m_Wrapper.m_CICActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ToggleWeaponOne.started += instance.OnToggleWeaponOne;
                    @ToggleWeaponOne.performed += instance.OnToggleWeaponOne;
                    @ToggleWeaponOne.canceled += instance.OnToggleWeaponOne;
                    @ToggleWeaponTwo.started += instance.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.performed += instance.OnToggleWeaponTwo;
                    @ToggleWeaponTwo.canceled += instance.OnToggleWeaponTwo;
                    @ToggleWeaponThree.started += instance.OnToggleWeaponThree;
                    @ToggleWeaponThree.performed += instance.OnToggleWeaponThree;
                    @ToggleWeaponThree.canceled += instance.OnToggleWeaponThree;
                    @ToggleWeaponFour.started += instance.OnToggleWeaponFour;
                    @ToggleWeaponFour.performed += instance.OnToggleWeaponFour;
                    @ToggleWeaponFour.canceled += instance.OnToggleWeaponFour;
                    @ToggleWeaponFive.started += instance.OnToggleWeaponFive;
                    @ToggleWeaponFive.performed += instance.OnToggleWeaponFive;
                    @ToggleWeaponFive.canceled += instance.OnToggleWeaponFive;
                    @ToggleWeaponSix.started += instance.OnToggleWeaponSix;
                    @ToggleWeaponSix.performed += instance.OnToggleWeaponSix;
                    @ToggleWeaponSix.canceled += instance.OnToggleWeaponSix;
                }
            }
        }
        public CICActions @CIC => new CICActions(this);
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
        public interface ICICActions
        {
            void OnToggleWeaponOne(InputAction.CallbackContext context);
            void OnToggleWeaponTwo(InputAction.CallbackContext context);
            void OnToggleWeaponThree(InputAction.CallbackContext context);
            void OnToggleWeaponFour(InputAction.CallbackContext context);
            void OnToggleWeaponFive(InputAction.CallbackContext context);
            void OnToggleWeaponSix(InputAction.CallbackContext context);
        }
    }
}
