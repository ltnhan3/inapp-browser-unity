using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    
    [SerializeField] private InputField _inputField;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            var uri = new UriBuilder(_inputField.text);
            StartBrowser(uri.Uri.ToString());
        });
    }

    // Start is called before the first frame update
    void StartBrowser(string url)
    {
#if UNITY_IOS && !UNITY_EDITOR
        this.gameObject.name = "YourSignInGameObject";
        SFSafariView.OpenURL( url );
#endif

#if  UNITY_ANDROID && !UNITY_EDITOR
        ChromeCustomTabs.OpenURL(url);
#endif

#if UNITY_EDITOR
        Application.OpenURL(url);
#endif

    }

    public void OnAuthCompleted()
    {
        Debug.Log( "SFSafariViewController が閉じられました" );
    }
}
