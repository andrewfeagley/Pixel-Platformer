// GENERATED AUTOMATICALLY FROM 'Assets/Player_One_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_One_Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_One_Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_One_Controls"",
    ""maps"": [
        {
            ""name"": ""Fight"",
            ""id"": ""b88c5574-fa7a-4be8-8611-aea23f5fabea"",
            ""actions"": [
                {
                    ""name"": ""JumpPressDown"",
                    ""type"": ""Button"",
                    ""id"": ""6f7e9f4f-9037-442e-8bac-0c9c7f25488e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack 0"",
                    ""type"": ""Button"",
                    ""id"": ""429c4ba9-6032-4d7b-b721-7354dfed6958"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack 1"",
                    ""type"": ""PassThrough"",
                    ""id"": ""02b31c84-c5fb-4282-a85c-55f1363344e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""63841e1d-121a-49b8-a16a-327623963f6e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ff971f1d-bb29-4746-9673-0e37569d40c8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""JumpPressDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09593635-d56d-4de1-a636-4c465a8d3da8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""JumpPressDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c538c06a-ab96-4df9-b602-b6432dbc69e9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Attack 0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a47fcd8-b18f-4cf4-a40d-ec13b6267b89"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Attack 0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""6669423d-8326-4003-aa42-df8d094199da"",
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
                    ""id"": ""c41f1e78-9e1c-45bd-b02a-9c51a54dbe83"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""be6be792-5f69-4e77-b83d-3e61d7657142"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a282b89b-8609-42a0-901a-63db654900f4"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e59a7753-f511-4eb1-b05f-2f5504383b46"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""69f5b335-2595-4a0d-8061-83e59c3cd6d5"",
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
                    ""id"": ""4bb07623-10ee-4329-85e3-591cb469519c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""96d2ca65-c826-4e2b-8001-6c26212bfad7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1dd146e7-942c-4889-8300-6a04f36d9e01"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""084b0a54-1ac6-4772-aa4b-1e40f773d491"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""24d6f60e-12c2-4d44-9c6a-f50145920803"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Attack 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9fc7d51-35e8-4283-843c-4891c06d2cc3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Basic"",
                    ""action"": ""Attack 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Basic"",
            ""bindingGroup"": ""Basic"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Fight
        m_Fight = asset.FindActionMap("Fight", throwIfNotFound: true);
        m_Fight_JumpPressDown = m_Fight.FindAction("JumpPressDown", throwIfNotFound: true);
        m_Fight_Attack0 = m_Fight.FindAction("Attack 0", throwIfNotFound: true);
        m_Fight_Attack1 = m_Fight.FindAction("Attack 1", throwIfNotFound: true);
        m_Fight_Move = m_Fight.FindAction("Move", throwIfNotFound: true);
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

    // Fight
    private readonly InputActionMap m_Fight;
    private IFightActions m_FightActionsCallbackInterface;
    private readonly InputAction m_Fight_JumpPressDown;
    private readonly InputAction m_Fight_Attack0;
    private readonly InputAction m_Fight_Attack1;
    private readonly InputAction m_Fight_Move;
    public struct FightActions
    {
        private @Player_One_Controls m_Wrapper;
        public FightActions(@Player_One_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JumpPressDown => m_Wrapper.m_Fight_JumpPressDown;
        public InputAction @Attack0 => m_Wrapper.m_Fight_Attack0;
        public InputAction @Attack1 => m_Wrapper.m_Fight_Attack1;
        public InputAction @Move => m_Wrapper.m_Fight_Move;
        public InputActionMap Get() { return m_Wrapper.m_Fight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FightActions set) { return set.Get(); }
        public void SetCallbacks(IFightActions instance)
        {
            if (m_Wrapper.m_FightActionsCallbackInterface != null)
            {
                @JumpPressDown.started -= m_Wrapper.m_FightActionsCallbackInterface.OnJumpPressDown;
                @JumpPressDown.performed -= m_Wrapper.m_FightActionsCallbackInterface.OnJumpPressDown;
                @JumpPressDown.canceled -= m_Wrapper.m_FightActionsCallbackInterface.OnJumpPressDown;
                @Attack0.started -= m_Wrapper.m_FightActionsCallbackInterface.OnAttack0;
                @Attack0.performed -= m_Wrapper.m_FightActionsCallbackInterface.OnAttack0;
                @Attack0.canceled -= m_Wrapper.m_FightActionsCallbackInterface.OnAttack0;
                @Attack1.started -= m_Wrapper.m_FightActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_FightActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_FightActionsCallbackInterface.OnAttack1;
                @Move.started -= m_Wrapper.m_FightActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FightActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FightActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_FightActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JumpPressDown.started += instance.OnJumpPressDown;
                @JumpPressDown.performed += instance.OnJumpPressDown;
                @JumpPressDown.canceled += instance.OnJumpPressDown;
                @Attack0.started += instance.OnAttack0;
                @Attack0.performed += instance.OnAttack0;
                @Attack0.canceled += instance.OnAttack0;
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public FightActions @Fight => new FightActions(this);
    private int m_BasicSchemeIndex = -1;
    public InputControlScheme BasicScheme
    {
        get
        {
            if (m_BasicSchemeIndex == -1) m_BasicSchemeIndex = asset.FindControlSchemeIndex("Basic");
            return asset.controlSchemes[m_BasicSchemeIndex];
        }
    }
    public interface IFightActions
    {
        void OnJumpPressDown(InputAction.CallbackContext context);
        void OnAttack0(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
