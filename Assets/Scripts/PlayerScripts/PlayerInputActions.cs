// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerScripts/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fa9d2988-98c5-4c77-8aab-f6baaabd3ac7"",
            ""actions"": [
                {
                    ""name"": ""Fire1"",
                    ""type"": ""Value"",
                    ""id"": ""c4aa4a21-f109-4c0a-a21e-d83b30c24542"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""dfd16152-091d-413b-8f0d-9a867fc9bf7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""b1d96dc9-552c-4e1e-9494-be64512ba9ce"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChargeAttack"",
                    ""type"": ""Button"",
                    ""id"": ""5d62cc02-d208-437d-96dd-f66559f173b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""88a5a595-5abb-48ca-9bfe-cf5abf901ee6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1087d35b-4a4e-47cd-8907-5bc255483320"",
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
                    ""id"": ""060f50ac-8d36-4dcb-9a53-fcb651372711"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cab805d0-89f0-4abe-93a8-37ca568ed89b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""59621c37-bd9e-4e9a-ad70-936f28e4d4e4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5af0df98-ff95-4dec-8324-a487755bf44e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""092ea189-fa7d-47ea-af96-61fdd9059b72"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""69f2a00f-a2a6-4d33-b303-a7d8106577c2"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a0c35faf-f588-41ea-b5dd-421c7e6f9bab"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ee5446b2-a537-4e1e-8c41-2a1744f4138d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""e3d03609-0b00-4a4b-834e-1ef2c8335082"",
            ""actions"": [
                {
                    ""name"": ""PuaseGame"",
                    ""type"": ""Button"",
                    ""id"": ""6ed3364a-c744-4953-b74a-5a1f5c5c797a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9eef853b-ca97-49f3-aeaa-49a8e9005d0b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PuaseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Fire1 = m_Player.FindAction("Fire1", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Rotation = m_Player.FindAction("Rotation", throwIfNotFound: true);
        m_Player_ChargeAttack = m_Player.FindAction("ChargeAttack", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PuaseGame = m_UI.FindAction("PuaseGame", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Fire1;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Rotation;
    private readonly InputAction m_Player_ChargeAttack;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire1 => m_Wrapper.m_Player_Fire1;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Rotation => m_Wrapper.m_Player_Rotation;
        public InputAction @ChargeAttack => m_Wrapper.m_Player_ChargeAttack;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Fire1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire1;
                @Fire1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire1;
                @Fire1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire1;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Rotation.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                @ChargeAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargeAttack;
                @ChargeAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargeAttack;
                @ChargeAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargeAttack;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire1.started += instance.OnFire1;
                @Fire1.performed += instance.OnFire1;
                @Fire1.canceled += instance.OnFire1;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @ChargeAttack.started += instance.OnChargeAttack;
                @ChargeAttack.performed += instance.OnChargeAttack;
                @ChargeAttack.canceled += instance.OnChargeAttack;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_PuaseGame;
    public struct UIActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PuaseGame => m_Wrapper.m_UI_PuaseGame;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @PuaseGame.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPuaseGame;
                @PuaseGame.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPuaseGame;
                @PuaseGame.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPuaseGame;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PuaseGame.started += instance.OnPuaseGame;
                @PuaseGame.performed += instance.OnPuaseGame;
                @PuaseGame.canceled += instance.OnPuaseGame;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnFire1(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnChargeAttack(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPuaseGame(InputAction.CallbackContext context);
    }
}
