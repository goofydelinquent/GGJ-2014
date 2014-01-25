using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour {

	public int grid_x = -1;
	public int grid_y = -1;

	public GridObjectType type;


}

public enum GridObjectType{
	GRIDOBJECTTYPE_GUMSHOE = 0,
	GRIDOBJECTTYPE_CANDY
}