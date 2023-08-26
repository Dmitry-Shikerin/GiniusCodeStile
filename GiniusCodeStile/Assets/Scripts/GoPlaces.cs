using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Transform _allPlacesPoint;

    private Transform[] _arrayPlaces;
    private int _numberOfPlace;

    void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    public void Update()
    {
        Transform pointByNumberInArray = _arrayPlaces[_numberOfPlace];

        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _duration * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position) 
            NextPlaceTakerLogic();
    }

    public Vector3 NextPlaceTakerLogic()
    {
        _numberOfPlace++;

        if (_numberOfPlace == _arrayPlaces.Length)
            _numberOfPlace = 0;

        Vector3 thisPointVector = _arrayPlaces[_numberOfPlace].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}
