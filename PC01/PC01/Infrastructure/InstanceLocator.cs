
namespace PC01.Infrastructure
{
    using ViewModels;

    public class InstanceLocator
    {
        public WelcomeViewModel WvM { get; set; }
        public LoginViewModel LvM { get; set; }
        public RegisterViewModel RvM { get; set; }
        public MainViewModel MvM { get; set; }
        public ContentViewModel CvM { get; set; }

        public InstanceLocator()
        {
            WvM = new WelcomeViewModel();
            LvM = new LoginViewModel();
            RvM = new RegisterViewModel();
            MvM = new MainViewModel();
            CvM = new ContentViewModel();
        }
    }
}
