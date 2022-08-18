using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    [SerializeField] private bool startinVR = true;
    [SerializeField] private GameObject xrOrigin;
    [SerializeField] private GameObject testPlayer;

    void Start()
    {
        if (!startinVR)
        {
            xrOrigin.SetActive(false);
            testPlayer.SetActive(true);//Turn on test player if not HMD detected
        }
        else
        {
            var xrSettings = XRGeneralSettings.Instance;
            if (xrSettings == null)
            {
                Debug.Log("XRGeneralSettings is null");
                return;
            }

            var xrManager = xrSettings.Manager;
            if (xrManager == null)
            {
                Debug.Log("XRManagerSettings is null");
                return;
            }

            var xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                Debug.Log("XRLoader is null");// If HMD not detected
                xrOrigin.SetActive(false);
                testPlayer.SetActive(true);
            }

            Debug.Log("XRLoader is present");// If HMD not detected
            xrOrigin.SetActive(true);
            testPlayer.SetActive(false);

        }

    }
}
