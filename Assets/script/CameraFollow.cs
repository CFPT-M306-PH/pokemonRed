using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public Transform target; 

	void LateUpdate()
	{
		if (target != null)
		{
			transform.position = new Vector3(target.position.x, target.position.y, -10);
		}
	}
}
