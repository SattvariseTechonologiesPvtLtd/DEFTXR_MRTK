using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DEFTXR
{


    public class mrtk_intct : MonoBehaviour
    {
        public static mrtk_intct Instance;

        public GameObject touch_pos;



        private void Awake()
        {
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
