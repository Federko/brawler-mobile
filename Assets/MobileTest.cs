using UnityEngine.UI;
using UnityEngine;

public class MobileTest : MonoBehaviour
{
    public static string DeviceUniqueIdentifier;
    public Text text;
    // Use this for initialization
    void Start()
    {
        DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
        text = GetComponentInChildren<Text>();
        text.text = DeviceUniqueIdentifier;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
