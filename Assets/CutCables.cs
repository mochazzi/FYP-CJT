using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice; //Asset from https://github.com/DavidArayan/ezy-slice
using UnityEngine.InputSystem;

public class CutCable : MonoBehaviour
{
    public Transform startSlice;
    public Transform endSlice;
    public LayerMask sliceableLayer;
    public VelocityEstimator velocityEstimator;
    public GameObject target;
    public Material crossSectionMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlice.position, endSlice.position, out RaycastHit hit, sliceableLayer);
        
        //If the cutter part hits the cable, slice it where they intersect
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Cut(target);
        }
    }

    public void Cut(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlice.position - startSlice.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlice.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedCable(upperHull);

            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedCable(lowerHull);

            //Destroy(target);
        }
    }

    //Creates separate rigidbody and mesh for the cable parts that were sliced
    public void SetupSlicedCable(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
    }

}