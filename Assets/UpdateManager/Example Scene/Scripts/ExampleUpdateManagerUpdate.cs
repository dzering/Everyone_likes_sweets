using UpdateManager.Scripts;

namespace UpdateManager.Example_Scene.Scripts
{
    public class ExampleUpdateManagerUpdate : OverridableMonoBehaviour {
        private int i;

        public override void UpdateMe() {
            i++;
        }
    }
}