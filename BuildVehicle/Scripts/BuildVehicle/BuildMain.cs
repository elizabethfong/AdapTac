// So this was here when I created the class. I am assuming that it can be useful?
using System ;

// EF:
// So this class is the main class that runs the build portion 
// of the game (at least, the way I see it)
// I am not sure if it should extend Monobehaviour but since PartManager
// in the PartManager folder did, I'm just going to use it =D
public class BuildMain : MonoBehaviour
{
	// Action Plan:
	// 1. Get the parts somehow

	// I am following the syntax used in PartManager.cs
	// it seems to be the class that manages all the parts in the game...
	private Dictionary<string , Dictionary<string , Part>> parts ;


}
