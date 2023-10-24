using AimRobot.Api;
using AimRobot.Api.plugin;

namespace ar_example_plugin {
    public class Class1 : PluginBase {

        public override string GetAuthor() {
            return "jiamingzhang";
        }

        public override string GetDescription() {
            return "kpm限制插件，kpm<2";
        }

        public override string GetPluginName() {
            return "ar-example-plugin";
        }

        public override Version GetVersion() {
            return new Version(1, 0, 0);
        }

        public override void OnDisable() {
            
        }

        public override void OnEnable() {
            
        }

        public override void OnLoad() {
            Robot.GetInstance().GetPluginManager().RegisterListener(this, new MyPluginEventListener());

            //这是监听指令的
           
        }

    }
}