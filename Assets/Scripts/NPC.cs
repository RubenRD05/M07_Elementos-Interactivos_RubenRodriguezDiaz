using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI; 

public class NPC : MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject UI;
    public GameObject exitButton; 
    private PlayerMover _playerMover;
    private bool _canBuy = true;
    private float time = 1f;
    public GameObject HUD;

    private void Start()
    {
        if (exitButton != null)
        {
            exitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
       if(_canBuy)
       {
         VCamDisable.gameObject.SetActive(false);
         VCamEnable.gameObject.SetActive(true);
         Camera.main.GetComponent<CinemachineBrain>().enabled = true;
         Camera.main.cullingMask &= ~(1 << 8);
         _playerMover = other.GetComponent<PlayerMover>();
         _playerMover.canMove = false;
         UI.SetActive(true);
         HUD.SetActive(false);
         exitButton.SetActive(true); 
         _canBuy = false;
       }
    }

    private void OnTriggerExit(Collider other) 
    {
      StartCoroutine(WaitForABit());
    }

    public void ExitStore()
    {
       _playerMover.canMove = true;
       VCamDisable.gameObject.SetActive(true);
       VCamEnable.gameObject.SetActive(false);
       Camera.main.GetComponent<CinemachineBrain>().enabled = false;
       Camera.main.cullingMask |= (1 << 8);
       HUD.SetActive(true);
       UI.SetActive(false);
       exitButton.SetActive(false); 
    }

    private IEnumerator WaitForABit()
    {
       yield return new WaitForSeconds(time);
       _canBuy = true;
    }

    private void OnExitButtonClick()
    {
        ExitStore();
    }
}
