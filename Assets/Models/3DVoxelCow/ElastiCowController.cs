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
            int count = 0;
            foreach (GameObject leg in legs)
            {
                Vector3 newScale = new Vector3(_legsScaleCache[count].x, _legsScaleCache[count].y + height,
                    _legsScaleCache[count].z);
                leg.transform.localScale = newScale;
            
                count++;
            }

            if (this.transform.position.y+heightDiff > 0){
                this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y+heightDiff,this.transform.position.z);
            }
            _lastHeight = height;

        }
    }
}
