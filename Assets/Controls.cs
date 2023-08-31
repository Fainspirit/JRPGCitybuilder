//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Global"",
            ""id"": ""04d01639-9bb3-430c-b292-34171ad0ab7c"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""900f0f02-c190-4d94-96a8-9780fc3ec60b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""b276a825-9cb5-4740-bdff-60f684932c86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""67e4c15a-83d9-4b07-8f50-e66c6a48a91c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""One"",
                    ""type"": ""Button"",
                    ""id"": ""b87a43bc-be41-4a62-8065-916bc86ffa20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Two"",
                    ""type"": ""Button"",
                    ""id"": ""96b048e4-f863-433e-bdda-dc8a71879456"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Three"",
                    ""type"": ""Button"",
                    ""id"": ""22edc240-78c8-4be8-9cec-38bcbdc760db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Four"",
                    ""type"": ""Button"",
                    ""id"": ""d6602640-ffe9-4d71-88a8-fd549752249c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""08392f1a-b9dc-4216-81f1-9dd9b90114f7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6441fae-be10-441c-8311-b5d981948529"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c3fd12a-49aa-4388-ae01-3b84999af6e8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b7911e3-235f-4b1a-a59a-45230ae24feb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5aa8ff38-5132-4511-8d98-c683687b28c6"",
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
                    ""id"": ""5c57c237-c5f6-4f2b-9979-f7006cae9bdc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""57153a87-2753-4390-806a-c0b72aa73ee6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9e74bd2c-4b78-4f95-ae9d-a853d57f8025"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c663e46f-c780-4fbd-951f-93ffa1fbcca2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ebd3b951-567a-4d2e-bbd5-198d534c4bf2"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""One"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""634b1364-a33a-472b-9662-230fe68e7f02"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Two"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""879c2bfd-6d78-45fc-8ef6-1e47a1939f75"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Three"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9585e9b-ed22-4f20-bd4c-3e3dfb341222"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Four"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_Confirm = m_Global.FindAction("Confirm", throwIfNotFound: true);
        m_Global_Cancel = m_Global.FindAction("Cancel", throwIfNotFound: true);
        m_Global_Move = m_Global.FindAction("Move", throwIfNotFound: true);
        m_Global_One = m_Global.FindAction("One", throwIfNotFound: true);
        m_Global_Two = m_Global.FindAction("Two", throwIfNotFound: true);
        m_Global_Three = m_Global.FindAction("Three", throwIfNotFound: true);
        m_Global_Four = m_Global.FindAction("Four", throwIfNotFound: true);
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

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_Confirm;
    private readonly InputAction m_Global_Cancel;
    private readonly InputAction m_Global_Move;
    private readonly InputAction m_Global_One;
    private readonly InputAction m_Global_Two;
    private readonly InputAction m_Global_Three;
    private readonly InputAction m_Global_Four;
    public struct GlobalActions
    {
        private @Controls m_Wrapper;
        public GlobalActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_Global_Confirm;
        public InputAction @Cancel => m_Wrapper.m_Global_Cancel;
        public InputAction @Move => m_Wrapper.m_Global_Move;
        public InputAction @One => m_Wrapper.m_Global_One;
        public InputAction @Two => m_Wrapper.m_Global_Two;
        public InputAction @Three => m_Wrapper.m_Global_Three;
        public InputAction @Four => m_Wrapper.m_Global_Four;
        public InputActionMap Get() { return m_Wrapper.m_Global; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalActions instance)
        {
            if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnConfirm;
                @Cancel.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCancel;
                @Move.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMove;
                @One.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnOne;
                @One.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnOne;
                @One.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnOne;
                @Two.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnTwo;
                @Two.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnTwo;
                @Two.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnTwo;
                @Three.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnThree;
                @Three.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnThree;
                @Three.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnThree;
                @Four.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnFour;
                @Four.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnFour;
                @Four.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnFour;
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @One.started += instance.OnOne;
                @One.performed += instance.OnOne;
                @One.canceled += instance.OnOne;
                @Two.started += instance.OnTwo;
                @Two.performed += instance.OnTwo;
                @Two.canceled += instance.OnTwo;
                @Three.started += instance.OnThree;
                @Three.performed += instance.OnThree;
                @Three.canceled += instance.OnThree;
                @Four.started += instance.OnFour;
                @Four.performed += instance.OnFour;
                @Four.canceled += instance.OnFour;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);
    public interface IGlobalActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnOne(InputAction.CallbackContext context);
        void OnTwo(InputAction.CallbackContext context);
        void OnThree(InputAction.CallbackContext context);
        void OnFour(InputAction.CallbackContext context);
    }
}
