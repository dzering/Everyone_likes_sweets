using UnityEngine;

namespace Test
{
    public class EntryPoint : MonoBehaviour
	{
		Client client;

        private void Start()
        {
			client = new Client(new TankFactory());
			client.Run();

            client = new Client(new AircraftFactory());
            client.Run();
        }
    }

}

