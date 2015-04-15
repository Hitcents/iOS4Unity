using MonoTouch.Foundation;
using MonoTouch.NUnit.UI;
using MonoTouch.UIKit;

namespace Tests
{
    [Register("UnitTestAppDelegate")]
    public partial class UnitTestAppDelegate : UIApplicationDelegate
    {
        private UIWindow window;
        private TouchRunner runner;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(MonoTouch.UIKit.UIScreen.MainScreen.Bounds);
            runner = new TouchRunner(window);

            // register every tests included in the main application/assembly
            runner.Add(System.Reflection.Assembly.GetExecutingAssembly());

            window.RootViewController = new UINavigationController(runner.GetViewController());
            window.MakeKeyAndVisible();

            return true;
        }
    }
}