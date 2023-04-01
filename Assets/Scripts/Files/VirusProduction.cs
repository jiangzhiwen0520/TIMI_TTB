using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusProduction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;//病毒子弹预制件
    public int numsOfBullets;//发射数量
    public float frequency;//发射频率
    public Vector2 speed;
    private bool m_canShoot=false;
    private float m_times = 0;
    private bool m_canShoot2 = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (!GetComponent<fileMove>().GetStop())
        {
            if (m_canShoot&& m_canShoot2)
            {
                m_times += Time.deltaTime;
                if (m_times >= frequency)
                {
                    for (int i = 0; i < numsOfBullets; ++i)
                    {
                        // 随机旋转子弹生成点
                        float randomAngle = Random.Range(-180, 180);
                        Transform bulletSpawnPoint = transform;
                        bulletSpawnPoint.Rotate(0, 0, randomAngle);
                        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
                        bullet.GetComponent<BulletController>().SetMoveVector(bulletSpawnPoint.right * Random.Range(speed.x, speed.y));
                        bulletSpawnPoint.Rotate(0, 0, -randomAngle);
                        //GameObject go = Instantiate(bullet);
                        //go.transform.position = transform.position;
                        //go.GetComponent<BulletController>().SetMoveVector(gameObject.GetComponent<fileMove>().GetMoveVecor());
                        //Destroy(go, 1);
                    }
                    m_times = 0;
                }
                    
            }
        }
    }

    public void SetCanShoot(bool b)
    {
        m_canShoot = b;
        m_times = 0;
    }
    public void SetCanShoot2(bool b)
    {
        m_canShoot2 = b;
    }
}
