using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowObject : MonoBehaviour
{
	[Header("Configuracion Objetivo")]
	public Transform objetivo;
	public Vector2 desfase;

	[Header("Movimiento")]
	// Speed used to move towards the target
	public float velocidad = 1f;

	private Rigidbody2D rigidB2D;

	private void Start()
	{
		rigidB2D = GetComponent<Rigidbody2D>();
	}

	// FixedUpdate is called once per frame
	void FixedUpdate()
	{
		//do nothing if the target hasn't been assigned or it was detroyed for some reason
		if (objetivo == null)
			return;

		//Move towards the target
		rigidB2D.MovePosition(Vector2.Lerp(transform.position, objetivo.position + (Vector3)desfase, Time.fixedDeltaTime * velocidad));

	}
}