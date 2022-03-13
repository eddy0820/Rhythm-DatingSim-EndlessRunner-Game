// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""06c038ac-3628-4f38-94f1-93638926d7c5"",
            ""actions"": [
                {
                    ""name"": ""Hit Note"",
                    ""type"": ""Button"",
                    ""id"": ""bc703d6e-8a75-4260-806b-59dfe09a3275"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start Music"",
                    ""type"": ""Button"",
                    ""id"": ""b42cab4c-e146-4a1a-af43-cf861a15bc59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GoUp"",
                    ""type"": ""Button"",
                    ""id"": ""b9cc2864-fcc7-44d7-8be9-723902dc22d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GoDown"",
                    ""type"": ""Button"",
                    ""id"": ""ac0e381a-da5b-4b0c-aa6e-b99654995905"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d57b1f9d-aa3f-4597-be4e-a5bd04a78538"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hit Note"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""967463e1-acd0-467f-8619-e1d613e3f266"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start Music"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9529ed61-42cc-4bbe-9ba4-427b20c459dc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0f93b12-8bf1-44ef-aaf8-ee6d6ca5f8d9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""bindingGroup"": ""Keyboard/Mouse"",
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
        m_Player_HitNote = m_Player.FindAction("Hit Note", throwIfNotFound: true);
        m_Player_StartMusic = m_Player.FindAction("Start Music", throwIfNotFound: true);
        m_Player_GoUp = m_Player.FindAction("GoUp", throwIfNotFound: true);
        m_Player_GoDown = m_Player.FindAction("GoDown", throwIfNotFound: true);
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
    private readonly InputAction m_Player_HitNote;
    private readonly InputAction m_Player_StartMusic;
    private readonly InputAction m_Player_GoUp;
    private readonly InputAction m_Player_GoDown;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HitNote => m_Wrapper.m_Player_HitNote;
        public InputAction @StartMusic => m_Wrapper.m_Player_StartMusic;
        public InputAction @GoUp => m_Wrapper.m_Player_GoUp;
        public InputAction @GoDown => m_Wrapper.m_Player_GoDown;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @HitNote.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHitNote;
                @HitNote.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHitNote;
                @HitNote.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHitNote;
                @StartMusic.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartMusic;
                @StartMusic.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartMusic;
                @StartMusic.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartMusic;
                @GoUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoUp;
                @GoUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoUp;
                @GoUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoUp;
                @GoDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoDown;
                @GoDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoDown;
                @GoDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoDown;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HitNote.started += instance.OnHitNote;
                @HitNote.performed += instance.OnHitNote;
                @HitNote.canceled += instance.OnHitNote;
                @StartMusic.started += instance.OnStartMusic;
                @StartMusic.performed += instance.OnStartMusic;
                @StartMusic.canceled += instance.OnStartMusic;
                @GoUp.started += instance.OnGoUp;
                @GoUp.performed += instance.OnGoUp;
                @GoUp.canceled += instance.OnGoUp;
                @GoDown.started += instance.OnGoDown;
                @GoDown.performed += instance.OnGoDown;
                @GoDown.canceled += instance.OnGoDown;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard/Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnHitNote(InputAction.CallbackContext context);
        void OnStartMusic(InputAction.CallbackContext context);
        void OnGoUp(InputAction.CallbackContext context);
        void OnGoDown(InputAction.CallbackContext context);
    }
}
