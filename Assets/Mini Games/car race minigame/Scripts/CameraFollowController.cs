using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour {
	public string input;
	public int index;
	public static int i=0;
	public static int indexForCalibrate;
	public GenericObjectArray objectToFollow;
	public float followSpeed = 10;
	public float lookSpeed = 10;
	public bool finishGame = false;
	public bool deathOrNot = false;
	public static bool calibrateIndexBool = false;
	public Vector3 offset;
	public static CameraFollowController Instance;
	private void Awake() {
		Instance=this;
	}
	public void LookAtTarget()
	{
		Vector3 _lookDirection = objectToFollow.SetCurrentMember(index).transform.position - transform.position; //razlika izmedju vector3 pozicija kamere i kola
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
	}
	public void MoveToTarget()
	{
		Vector3 targetPos = objectToFollow.MemberWithIndex(index).transform.position +
							objectToFollow.MemberWithIndex(index).transform.forward * offset.z +
							objectToFollow.MemberWithIndex(index).transform.right * offset.x +
							objectToFollow.MemberWithIndex(index).transform.up * offset.y;
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
	}
	private void FixedUpdate()
	{
		LookAtTarget();
		MoveToTarget();
	}
	private void Update()
	{
		if (calibrateIndexBool) 
		{
			CallibrateIndex();
		}
		if (Input.GetKeyDown(input) && deathOrNot)
		{
			ChangeIndex(index);
		}
	}
	public void ChangeIndex(int index)
	{
		if (finishGame)
		{
			indexForCalibrate = index;
			objectToFollow.ExcludeElement(index);
			finishGame = false;
			calibrateIndexBool = true;
		}
		index++;
		if (!objectToFollow.MemberWithIndex(index).activeSelf)
		{
			ChangeIndex(index);
		}
		this.index = index;
	}
	public void CallibrateIndex() 
	{
		i++;
		if (index>indexForCalibrate)
		{
			index--;
		}
		if (i == 4) {
			calibrateIndexBool = false;
			i= 0;
		}
	}
}