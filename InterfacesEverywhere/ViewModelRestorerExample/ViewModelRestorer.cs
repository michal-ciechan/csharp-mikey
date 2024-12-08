namespace InterfacesEverywhere.ViewModelRestorerExample;

public interface IViewModelRestorer
{
    void RestoreState(object state);
}

public class ViewModelRestorer : IViewModelRestorer
{
    private IViewModel _viewModel;

    public ViewModelRestorer(IViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void RestoreState(object state)
    {
        // Restore whole view model from saved state.
        // 200-300 lines of code of very specific ordering and logic.

        _viewModel.PrivateState1 = 0;
        _viewModel.PrivateState1 = 0;
        _viewModel.PrivateState1 = 0;
        _viewModel.PrivateState1 = 0;
        _viewModel.PrivateState1 = 0;

        _viewModel.PublicState1 = "";
        _viewModel.PublicState2 = "";
        _viewModel.PublicState3 = "";
        _viewModel.PublicState4 = "";
        _viewModel.PublicState5 = "";

        _viewModel.InternalBusinessLogic1(0);
        _viewModel.InternalBusinessLogic2(0);
        _viewModel.InternalBusinessLogic3(0);
        _viewModel.InternalBusinessLogic4(0);
        _viewModel.InternalBusinessLogic5(0);

        _viewModel.PublicBusinessLogic1();
        _viewModel.PublicBusinessLogic2();
        _viewModel.PublicBusinessLogic3();
        _viewModel.PublicBusinessLogic4();
        _viewModel.PublicBusinessLogic5();
    }
}

        public interface IThis 
        {
        }
        public interface IThat 
        {
            
        }
        public interface IEverywhere 
{
}


public class Test :
    IThis,
    IThat,
    IEverywhere
{
    public void TestMethod()
    {
        Console.WriteLine("Test method");
    }
}
