namespace ctrujilloS5A
{
    public partial class App : Application
    {
        public static Repository.PersonRepository personRepo {  get; set; }
        public App(Repository.PersonRepository personrepository)
        {
            InitializeComponent();
            personRepo = personrepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPrincipal());
        }
    }
}