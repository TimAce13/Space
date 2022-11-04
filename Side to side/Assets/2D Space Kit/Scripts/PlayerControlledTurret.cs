using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour, IDataPersistence
{

	public GameObject weapon_prefab;
	public GameObject[] barrel_hardpoints;
	public float shot_speed;
	int barrel_index = 0;

	[SerializeField] private int _shootedBullets = 0;
	
	[SerializeField] private GameObject[] _turrets;

	public void LoadData(GameData data)
	{
		this._shootedBullets = data.shootedBullets;
	}

	public void SaveData(GameData data)
	{
		data.shootedBullets = this._shootedBullets;
	}

	public void Shoot()
	{
		if (gameObject.activeSelf)
		{
			if (barrel_hardpoints != null)
			{
				if (barrel_index == 0)
				{
					for (int i = 0; i < barrel_hardpoints.Length; i += 2)
					{
						GameObject bullet = (GameObject) Instantiate(weapon_prefab,
							barrel_hardpoints[i].transform.position, _turrets[i / 2].transform.rotation);
						bullet.GetComponent<Rigidbody2D>()
							.AddForce(bullet.transform.up * shot_speed * Time.deltaTime * 50);
						bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;
						//barrel_index++; //This will cycle sequentially through the barrels in the barrel_hardpoints array
						_shootedBullets += 1;
					}
				}
				else if (barrel_index == 1)
				{
					for (int i = 1; i < barrel_hardpoints.Length; i += 2)
					{
						GameObject bullet = (GameObject) Instantiate(weapon_prefab,
							barrel_hardpoints[i].transform.position,
							_turrets[(int) Mathf.Floor(i / 2)].transform.rotation);
						bullet.GetComponent<Rigidbody2D>()
							.AddForce(bullet.transform.up * shot_speed * Time.deltaTime * 50);
						bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;
						//barrel_index++; //This will cycle sequentially through the barrels in the barrel_hardpoints array
						_shootedBullets += 1;
					}
				}

				if (barrel_index == 0)
				{
					barrel_index = 1;
				}
				else
				{
					barrel_index = 0;
				}
			}
		}
	}
}