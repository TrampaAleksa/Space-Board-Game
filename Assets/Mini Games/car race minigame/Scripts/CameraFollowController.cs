using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour {
	public Transform objectToFollow;
	public float followSpeed = 10;
	public float lookSpeed = 10;
	public Vector3 offset;

	public void LookAtTarget() 
	{
		Vector3 _lookDirection = objectToFollow.position - transform.position; //razlika izmedju vector3 pozicija kamere i kola
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
	}
	public void MoveToTarget() 
	{
		Vector3 targetPos = objectToFollow.position +
							objectToFollow.forward * offset.z +
							objectToFollow.right * offset.x +
							objectToFollow.up * offset.y;
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
	}
	private void FixedUpdate()
	{
		LookAtTarget();
		MoveToTarget();
		
	}



}
