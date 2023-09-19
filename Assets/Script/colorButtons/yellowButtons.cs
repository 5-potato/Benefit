using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yellowButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public Button yellowcolor;
    public Button redclothes1;
    public Button redclothes2;
    public Button redclothes3;
    public Button redclothes4;
    public Button redclothes5;
    public Button redclothes6;
    public Button redclothes7;
    public Button pinkclothes1;
    public Button pinkclothes2;
    public Button pinkclothes3;
    public Button pinkclothes4;
    public Button pinkclothes5;
    public Button pinkclothes6;
    public Button pinkclothes7;
    public Button yellowclothes1;
    public Button yellowclothes2;
    public Button yellowclothes3;
    public Button yellowclothes4;
    public Button yellowclothes5;
    public Button yellowclothes6;
    public Button yellowclothes7;
    public Button greenclothes1;
    public Button greenclothes2;
    public Button greenclothes3;
    public Button greenclothes4;
    public Button greenclothes5;
    public Button greenclothes6;
    public Button greenclothes7;
    public Button blueclothes1;
    public Button blueclothes2;
    public Button blueclothes3;
    public Button blueclothes4;
    public Button blueclothes5;
    public Button blueclothes6;
    public Button blueclothes7;
    public Button purpleclothes1;
    public Button purpleclothes2;
    public Button purpleclothes3;
    public Button purpleclothes4;
    public Button purpleclothes5;
    public Button purpleclothes6;
    public Button purpleclothes7;
    public Button blackclothes1;
    public Button blackclothes2;
    public Button blackclothes3;
    public Button blackclothes4;
    public Button blackclothes5;
    public Button blackclothes6;
    public Button blackclothes7;



    
    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        yellowcolor.onClick.AddListener(OnClickRedButtons);
    }

    void OnClickRedButtons()
    {
        redclothes1.gameObject.SetActive(false);
        redclothes2.gameObject.SetActive(false);   
        redclothes3.gameObject.SetActive(false);   
        redclothes4.gameObject.SetActive(false);   
        redclothes5.gameObject.SetActive(false);   
        redclothes6.gameObject.SetActive(false);   
        redclothes7.gameObject.SetActive(false);

        pinkclothes1.gameObject.SetActive(false);
        pinkclothes2.gameObject.SetActive(false);   
        pinkclothes3.gameObject.SetActive(false);   
        pinkclothes4.gameObject.SetActive(false);   
        pinkclothes5.gameObject.SetActive(false);   
        pinkclothes6.gameObject.SetActive(false);   
        pinkclothes7.gameObject.SetActive(false);  

        yellowclothes1.gameObject.SetActive(true);
        yellowclothes2.gameObject.SetActive(true); 
        yellowclothes3.gameObject.SetActive(true); 
        yellowclothes4.gameObject.SetActive(true); 
        yellowclothes5.gameObject.SetActive(true); 
        yellowclothes6.gameObject.SetActive(true); 
        yellowclothes7.gameObject.SetActive(true);

        greenclothes1.gameObject.SetActive(false); 
        greenclothes2.gameObject.SetActive(false); 
        greenclothes3.gameObject.SetActive(false);  
        greenclothes4.gameObject.SetActive(false);  
        greenclothes5.gameObject.SetActive(false);  
        greenclothes6.gameObject.SetActive(false);  
        greenclothes7.gameObject.SetActive(false);

        blueclothes1.gameObject.SetActive(false);
        blueclothes2.gameObject.SetActive(false);
        blueclothes3.gameObject.SetActive(false);
        blueclothes4.gameObject.SetActive(false);
        blueclothes5.gameObject.SetActive(false);
        blueclothes6.gameObject.SetActive(false);
        blueclothes7.gameObject.SetActive(false);

        purpleclothes1.gameObject.SetActive(false);
        purpleclothes2.gameObject.SetActive(false);
        purpleclothes3.gameObject.SetActive(false);
        purpleclothes4.gameObject.SetActive(false);
        purpleclothes5.gameObject.SetActive(false);
        purpleclothes6.gameObject.SetActive(false);
        purpleclothes7.gameObject.SetActive(false);
        
        blackclothes1.gameObject.SetActive(false);
        blackclothes2.gameObject.SetActive(false);
        blackclothes3.gameObject.SetActive(false);
        blackclothes4.gameObject.SetActive(false);
        blackclothes5.gameObject.SetActive(false);
        blackclothes6.gameObject.SetActive(false);
        blackclothes7.gameObject.SetActive(false);            
    }
}
