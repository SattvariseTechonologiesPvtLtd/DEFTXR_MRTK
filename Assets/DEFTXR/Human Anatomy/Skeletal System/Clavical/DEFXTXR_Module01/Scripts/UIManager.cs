using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   
    public string selectedBtnName;
   

    public GameObject zoneAPlat, zoneBplat, zoneCplat;
    public static UIManager Instance;

    public GameObject femurBone, tibiaBone, patellaBone, hipBone, fibulaBone, sacrumBone;
    public GameObject clavicleBone, scapulaBone, humerusBone, ulnaRadiusBone, carpalBone;
    //public GameObject clavicaleBone,scapulaBone,humerusBone,ulnaradiusBone,femurBone,tibiaBone,carpalBone,patellaBone,hipBone;
    
    // Sub-Menu reference to on off on click of buttn
    public GameObject upperLimbMenu, lowerLimbMenu, thoraxMenu, headneckbrainMenu,ComingSoonPanel;

   

   

    //Sprites to be replaced as per selection
    Sprite btnSelected, btnDselected;

    public GameObject mainUI;

    void Awake()
    {
        Instance = this;
    }


    private void Start()
    {

        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);

        mainUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       // ShootLaserFromTargetPosition(rightHand.transform.position, rightHand.transform.forward, laserMaxLength);

        //Call and select the UI as per laser collision
        //selectUIButton();

    }

    /// <summary>
    /// Methode will match the button selected by laser
    /// </summary>
    /// 
    public void onUpperLimbButtonClick()
    {
        upperLimbMenu.SetActive(true);
        lowerLimbMenu.SetActive(false);
        thoraxMenu.SetActive(false);
        headneckbrainMenu.SetActive(false);
    }

    public void onLowerLimbButtonClick()
    {
        upperLimbMenu.SetActive(false);
        lowerLimbMenu.SetActive(true);
        thoraxMenu.SetActive(false);
        headneckbrainMenu.SetActive(false);
    }

    public void onThoraxButtonClick()
    {
        upperLimbMenu.SetActive(false);
        lowerLimbMenu.SetActive(false);
        thoraxMenu.SetActive(true);
        headneckbrainMenu.SetActive(false);
    }

    public void onHNBButtonClick()
    {
        upperLimbMenu.SetActive(false);
        lowerLimbMenu.SetActive(false);
        thoraxMenu.SetActive(false);
        headneckbrainMenu.SetActive(true);

    }

    //Upper Limb Bones - 

    public void onClavicleButtonClick()
    {
        
        //Upper limb bones
        clavicleBone.SetActive(true);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);

        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        //zoneCplat.SetActive(true);

        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
    }

    public void onScapulaButtonClick()
    {
        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(true);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);


        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        //zoneCplat.SetActive(true);
        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
    }

    public void onHumerusButtonClick()
    {
        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(true);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);

        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);

        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
    }

    public void onUlnaRadiusButtonClick()
    {
        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(true);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);


        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);
    }

    public void onCarpalButtonClick()
    {

        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(true);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);


        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);
    }

    //Lower Limb Bones - 

    public void onFemurButtonClick()
    {
        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(true);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);


        //zoneBplat.SetActive(true);
        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);


    }
    

    public void onTibiaButtonClick()
    {

        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(true);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);

        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);
    }

    

    public void onPatellaButtonClick()
    {

        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(true);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);


        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);
    }

    public void onHipBoneButtonClick()
    {

        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(true);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);


        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);
    }

    public void onFibulaButtonClick()
    {

        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(true);
        sacrumBone.SetActive(false);


        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);
    }

    public void onSacrumButtonClick()
    {

        //Upper limb bones

        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(true);


        mainUI.SetActive(false);
        ComingSoonPanel.SetActive(false);
        //zoneAPlat.SetActive(true);
        //zoneBplat.SetActive(true);
        // zoneCplat.SetActive(true);
    }

    public void onCMPButtonClick()
    {
        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        femurBone.SetActive(false);

        ComingSoonPanel.SetActive(true);

    }

    public void onOkayButtonClick()
    {
        ComingSoonPanel.SetActive(false);
    }

    public void onHomeButtonClick()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void onSkeletonSystemHomeButtonClick()
    {
        clavicleBone.SetActive(false);
        scapulaBone.SetActive(false);
        humerusBone.SetActive(false);
        ulnaRadiusBone.SetActive(false);
        carpalBone.SetActive(false);

        //LowerLimb Bones
        femurBone.SetActive(false);
        tibiaBone.SetActive(false);
        patellaBone.SetActive(false);
        hipBone.SetActive(false);
        fibulaBone.SetActive(false);
        sacrumBone.SetActive(false);


        mainUI.SetActive(true);
    }




}
