using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private GameObject _prefab;
    [SerializeField] static private float s_timeWaitShooting;
    [SerializeField] private Transform _objectToShoot;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(s_timeWaitShooting);

    private void OnEnable()
    {
        _coroutine = StartCoroutine(ShootingWorker());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _number;

            yield return _waitForSeconds;
        }
    }
}
