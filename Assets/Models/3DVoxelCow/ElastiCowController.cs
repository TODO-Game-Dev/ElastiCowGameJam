using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElastiCowController : MonoBehaviour
{
    [SerializeField]
    private float height = 0;
    

    [SerializeField]
    private List<GameObject> legs;

    
    [SerializeField]
    private GameObject tongue;
    
    [SerializeField]
    private float tongueSize = 0;

    
    private List<Vector3> _legsScaleCache = new List<Vector3>();
    private float _lastHeight = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject leg in legs)
        {
            _legsScaleCache.Add(leg.transform.localScale);
        }
    }

    // Update is called once per frame
    void Update()
    {
        tongue.transform.localScale = new Vector3(tongueSize, 1, 3);
        if (height != _lastHeight)
        {
            var heightDiff = height- _lastHeight;
            //Vector3 amountDifference = new Vector3();
            //float difference = 0;
            int count = 0;
            foreach (GameObject leg in legs)
            {
                Vector3 newScale = new Vector3(_legsScaleCache[count].x, _legsScaleCache[count].y + height,
                    _legsScaleCache[count].z);
               // difference = leg.transform.position.y;
                ScaleAround(leg,leg.transform.GetChild(0).transform.position, newScale );
                /*amountDifference = leg.transform.position - leg.transform.GetChild(0).transform.position;

                difference -= newScale.y;*/
            
                count++;
            }

            //Debug.Log(heightDiff);
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y+heightDiff,this.transform.position.z);
            _lastHeight = height;

        }
    }
    
    
    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;
 
        Vector3 C = A - B; // diff from object pivot to desired pivot/origin
 
        float RS = newScale.x / target.transform.localScale.x; // relataive scale factor
 
        // calc final position post-scale
        Vector3 FP = B + C * RS;
 
        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }

    
}
