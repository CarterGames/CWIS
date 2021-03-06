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
                    ""type"": ""Button"",
                    ""id"": ""e23ddf8b-0172-4ccf-9a7f-e928c946ce3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""c25ac0a8-f8b6-4d46-b84b-16a314ae23cf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PositionJoystick"",
                    ""type"": ""Value"",
                    ""id"": ""2dc2e39a-c3ef-435a-8ad5-3a9e76c64e83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
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
                },
                {
                    ""name"": """",
                    ""id"": ""3fbc9e09-7bd0-4b19-87d6-697b4f8b7cc4"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""325a3cbe-e293-4239-86a2-d69eef87ff2a"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dd681a4-d3da-4b70-8352-d930b95e4235"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""PositionJoystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8377cf4-0e21-4912-be5d-1b79fae32731"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""PositionJoystick"",
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
                },
                {
                    ""name"": ""ToggleWesponUD"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7ace7bae-d0c8-46c9-bb5d-6d45d121e863"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.5)""
                },
                {
                    ""name"": ""ToggleWeaponAbility"",
                    ""type"": ""Button"",
                    ""id"": ""c2b5ab47-b0f6-48c7-a362-b38fca44039b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.5)""
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Button"",
                    ""id"": ""66a9d146-f14b-41cd-a83d-d705b4f709f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.5)""
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
                },
                {
                    ""name"": ""Bumpers"",
                    ""id"": ""39003782-4e92-45f6-b938-6493f5918475"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWesponUD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b7bdfdf0-cb81-4fdc-9d2a-8775115a3f1f"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""ToggleWesponUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a8c1d9f7-e1c4-4e0f-af3c-12f2d2dd49aa"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""ToggleWesponUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""41c692ca-965c-4d11-9774-e50cf9f7b0b0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ToggleWeaponAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""D-Pad U/D"",
                    ""id"": ""048ab2c7-3d73-463b-a34b-b9839b3d39a8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""275f5abb-f3f9-46d9-b098-c6228f325a21"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d9fa232c-c6a3-40ac-9bd8-c9852d62ff70"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3607dd60-8ff3-40f3-93f6-df15728248cc"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""7ddfc234-1695-4a34-a281-881c97f2f40a"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""PassThrough"",
                    ""id"": ""037818ea-5148-4c00-9168-af14761d2de1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Joystick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4a032fa-63d9-41a9-9ca0-29b94e1aba44"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""5104ffac-9387-45c1-bef5-e2cbd491aa23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""115e0a45-453e-4f3c-955d-5b3490700c8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""e28b566f-d152-44b7-93e4-cb72f33abbd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Keys"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1ef129bf-07ab-4d01-aa42-f1a426584dc3"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""46707c99-f34a-4f51-b8fe-19e5df1dabc4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d8034a4-a989-4b95-99ce-940932985365"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5de94cb7-af61-4b79-a49e-761682ec69f9"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e282dc0b-20f0-466c-a10d-59c7d64d2e93"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""03cd093a-c720-4c8d-a362-852439b01605"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d03b6276-4698-4a7b-910d-5aab74af18af"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bef528e2-26c1-454e-b1b1-7d1f53374b93"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81fd4d6f-f3f5-420f-a3c7-4f641a5d2fd1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4779025c-3b24-4ee4-a65e-f7154a577188"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""44451973-052a-4df0-97be-679ed715ec64"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c91f55fc-00e7-491b-9cfb-28755acb49f3"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50c18508-92f2-45a7-873f-b35e59506015"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2170628d-63d3-46aa-9d66-55572ce1e085"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d51b786-24e8-4f4f-96a3-6488aa23c58b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""045af1f2-543f-4074-8eaf-3b9f083ce08e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard-WASD"",
                    ""id"": ""23525aac-4f55-4186-b6ea-2e166207e98a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe38e446-8060-47b9-936c-728274572c0b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f9748d71-ddd9-4dd5-ab52-a14443015212"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""abe55048-b8ca-455d-9efd-46e1bfbe1179"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""41a2bf16-0750-4860-8634-50d47b08d0e0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard-Arrows"",
                    ""id"": ""5f3249f4-5e0f-4176-8a9f-95af3bd8a5b9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""784e47e3-0b53-432f-9513-1f3d777339ca"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6d7e6817-a961-4d0f-aa52-69b5b435d9b0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c3a60255-f28e-443a-bd94-a4aa92e9660b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f5412ce6-4dc3-49c3-8691-d9567afb1040"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Driver"",
            ""id"": ""032f47d4-00c2-46a0-921b-a28b1bedbf9a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1c16f2e3-4e37-4913-8709-ee375084a672"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""4b483c9f-9d73-4aa4-a838-a0c42d2f3df5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6021d7e8-5950-458f-85ba-ace62aee00ce"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d246bc2c-86a7-4931-8b60-da4fd6518ab9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e94a554b-5a69-4c5b-9c76-41fb3bd00128"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""99c19fd1-26a6-41aa-b76b-280aa1f99149"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""74e57515-cc1c-476b-a437-4b1e272915ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9d02bc03-d126-4e7a-a3ec-1ad12c7326fe"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""28bc4b6a-8ab3-45b3-9eff-b0722197cb1e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5cf5b853-8ea3-4de8-95ff-ea268b83cb3e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""03a02b98-8048-413d-b2c3-7393c50a0b91"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Weapons
            m_Weapons = asset.FindActionMap("Weapons", throwIfNotFound: true);
            m_Weapons_Fire = m_Weapons.FindAction("Fire", throwIfNotFound: true);
            m_Weapons_Position = m_Weapons.FindAction("Position", throwIfNotFound: true);
            m_Weapons_PositionJoystick = m_Weapons.FindAction("PositionJoystick", throwIfNotFound: true);
            // CIC
            m_CIC = asset.FindActionMap("CIC", throwIfNotFound: true);
            m_CIC_ToggleWeaponOne = m_CIC.FindAction("ToggleWeaponOne", throwIfNotFound: true);
            m_CIC_ToggleWeaponTwo = m_CIC.FindAction("ToggleWeaponTwo", throwIfNotFound: true);
            m_CIC_ToggleWeaponThree = m_CIC.FindAction("ToggleWeaponThree", throwIfNotFound: true);
            m_CIC_ToggleWeaponFour = m_CIC.FindAction("ToggleWeaponFour", throwIfNotFound: true);
            m_CIC_ToggleWeaponFive = m_CIC.FindAction("ToggleWeaponFive", throwIfNotFound: true);
            m_CIC_ToggleWeaponSix = m_CIC.FindAction("ToggleWeaponSix", throwIfNotFound: true);
            m_CIC_ToggleWesponUD = m_CIC.FindAction("ToggleWesponUD", throwIfNotFound: true);
            m_CIC_ToggleWeaponAbility = m_CIC.FindAction("ToggleWeaponAbility", throwIfNotFound: true);
            m_CIC_CameraZoom = m_CIC.FindAction("CameraZoom", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Pause = m_Menu.FindAction("Pause", throwIfNotFound: true);
            m_Menu_Joystick = m_Menu.FindAction("Joystick", throwIfNotFound: true);
            m_Menu_Map = m_Menu.FindAction("Map", throwIfNotFound: true);
            m_Menu_Back = m_Menu.FindAction("Back", throwIfNotFound: true);
            m_Menu_Accept = m_Menu.FindAction("Accept", throwIfNotFound: true);
            m_Menu_Keys = m_Menu.FindAction("Keys", throwIfNotFound: true);
            // Driver
            m_Driver = asset.FindActionMap("Driver", throwIfNotFound: true);
            m_Driver_Movement = m_Driver.FindAction("Movement", throwIfNotFound: true);
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
        private readonly InputAction m_Weapons_Position;
        private readonly InputAction m_Weapons_PositionJoystick;
        public struct WeaponsActions
        {
            private @Actions m_Wrapper;
            public WeaponsActions(@Actions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Fire => m_Wrapper.m_Weapons_Fire;
            public InputAction @Position => m_Wrapper.m_Weapons_Position;
            public InputAction @PositionJoystick => m_Wrapper.m_Weapons_PositionJoystick;
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
                    @Position.started -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnPosition;
                    @Position.performed -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnPosition;
                    @Position.canceled -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnPosition;
                    @PositionJoystick.started -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnPositionJoystick;
                    @PositionJoystick.performed -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnPositionJoystick;
                    @PositionJoystick.canceled -= m_Wrapper.m_WeaponsActionsCallbackInterface.OnPositionJoystick;
                }
                m_Wrapper.m_WeaponsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @Position.started += instance.OnPosition;
                    @Position.performed += instance.OnPosition;
                    @Position.canceled += instance.OnPosition;
                    @PositionJoystick.started += instance.OnPositionJoystick;
                    @PositionJoystick.performed += instance.OnPositionJoystick;
                    @PositionJoystick.canceled += instance.OnPositionJoystick;
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
        private readonly InputAction m_CIC_ToggleWesponUD;
        private readonly InputAction m_CIC_ToggleWeaponAbility;
        private readonly InputAction m_CIC_CameraZoom;
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
            public InputAction @ToggleWesponUD => m_Wrapper.m_CIC_ToggleWesponUD;
            public InputAction @ToggleWeaponAbility => m_Wrapper.m_CIC_ToggleWeaponAbility;
            public InputAction @CameraZoom => m_Wrapper.m_CIC_CameraZoom;
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
                    @ToggleWesponUD.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWesponUD;
                    @ToggleWesponUD.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWesponUD;
                    @ToggleWesponUD.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWesponUD;
                    @ToggleWeaponAbility.started -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponAbility;
                    @ToggleWeaponAbility.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponAbility;
                    @ToggleWeaponAbility.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnToggleWeaponAbility;
                    @CameraZoom.started -= m_Wrapper.m_CICActionsCallbackInterface.OnCameraZoom;
                    @CameraZoom.performed -= m_Wrapper.m_CICActionsCallbackInterface.OnCameraZoom;
                    @CameraZoom.canceled -= m_Wrapper.m_CICActionsCallbackInterface.OnCameraZoom;
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
                    @ToggleWesponUD.started += instance.OnToggleWesponUD;
                    @ToggleWesponUD.performed += instance.OnToggleWesponUD;
                    @ToggleWesponUD.canceled += instance.OnToggleWesponUD;
                    @ToggleWeaponAbility.started += instance.OnToggleWeaponAbility;
                    @ToggleWeaponAbility.performed += instance.OnToggleWeaponAbility;
                    @ToggleWeaponAbility.canceled += instance.OnToggleWeaponAbility;
                    @CameraZoom.started += instance.OnCameraZoom;
                    @CameraZoom.performed += instance.OnCameraZoom;
                    @CameraZoom.canceled += instance.OnCameraZoom;
                }
            }
        }
        public CICActions @CIC => new CICActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Pause;
        private readonly InputAction m_Menu_Joystick;
        private readonly InputAction m_Menu_Map;
        private readonly InputAction m_Menu_Back;
        private readonly InputAction m_Menu_Accept;
        private readonly InputAction m_Menu_Keys;
        public struct MenuActions
        {
            private @Actions m_Wrapper;
            public MenuActions(@Actions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_Menu_Pause;
            public InputAction @Joystick => m_Wrapper.m_Menu_Joystick;
            public InputAction @Map => m_Wrapper.m_Menu_Map;
            public InputAction @Back => m_Wrapper.m_Menu_Back;
            public InputAction @Accept => m_Wrapper.m_Menu_Accept;
            public InputAction @Keys => m_Wrapper.m_Menu_Keys;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                    @Joystick.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoystick;
                    @Joystick.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoystick;
                    @Joystick.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoystick;
                    @Map.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMap;
                    @Map.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMap;
                    @Map.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMap;
                    @Back.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                    @Back.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                    @Back.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                    @Accept.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnAccept;
                    @Accept.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnAccept;
                    @Accept.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnAccept;
                    @Keys.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnKeys;
                    @Keys.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnKeys;
                    @Keys.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnKeys;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @Joystick.started += instance.OnJoystick;
                    @Joystick.performed += instance.OnJoystick;
                    @Joystick.canceled += instance.OnJoystick;
                    @Map.started += instance.OnMap;
                    @Map.performed += instance.OnMap;
                    @Map.canceled += instance.OnMap;
                    @Back.started += instance.OnBack;
                    @Back.performed += instance.OnBack;
                    @Back.canceled += instance.OnBack;
                    @Accept.started += instance.OnAccept;
                    @Accept.performed += instance.OnAccept;
                    @Accept.canceled += instance.OnAccept;
                    @Keys.started += instance.OnKeys;
                    @Keys.performed += instance.OnKeys;
                    @Keys.canceled += instance.OnKeys;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);

        // Driver
        private readonly InputActionMap m_Driver;
        private IDriverActions m_DriverActionsCallbackInterface;
        private readonly InputAction m_Driver_Movement;
        public struct DriverActions
        {
            private @Actions m_Wrapper;
            public DriverActions(@Actions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Driver_Movement;
            public InputActionMap Get() { return m_Wrapper.m_Driver; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DriverActions set) { return set.Get(); }
            public void SetCallbacks(IDriverActions instance)
            {
                if (m_Wrapper.m_DriverActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_DriverActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_DriverActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_DriverActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_DriverActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public DriverActions @Driver => new DriverActions(this);
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
        private int m_XboxControllerSchemeIndex = -1;
        public InputControlScheme XboxControllerScheme
        {
            get
            {
                if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
                return asset.controlSchemes[m_XboxControllerSchemeIndex];
            }
        }
        public interface IWeaponsActions
        {
            void OnFire(InputAction.CallbackContext context);
            void OnPosition(InputAction.CallbackContext context);
            void OnPositionJoystick(InputAction.CallbackContext context);
        }
        public interface ICICActions
        {
            void OnToggleWeaponOne(InputAction.CallbackContext context);
            void OnToggleWeaponTwo(InputAction.CallbackContext context);
            void OnToggleWeaponThree(InputAction.CallbackContext context);
            void OnToggleWeaponFour(InputAction.CallbackContext context);
            void OnToggleWeaponFive(InputAction.CallbackContext context);
            void OnToggleWeaponSix(InputAction.CallbackContext context);
            void OnToggleWesponUD(InputAction.CallbackContext context);
            void OnToggleWeaponAbility(InputAction.CallbackContext context);
            void OnCameraZoom(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnPause(InputAction.CallbackContext context);
            void OnJoystick(InputAction.CallbackContext context);
            void OnMap(InputAction.CallbackContext context);
            void OnBack(InputAction.CallbackContext context);
            void OnAccept(InputAction.CallbackContext context);
            void OnKeys(InputAction.CallbackContext context);
        }
        public interface IDriverActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}
