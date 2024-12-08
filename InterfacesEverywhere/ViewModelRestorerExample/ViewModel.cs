namespace InterfacesEverywhere.ViewModelRestorerExample;

public interface IViewModel
{
    int PrivateState1 { get; set; }
    int PrivateState2 { get; set; }
    int PrivateState3 { get; set; }
    int PrivateState4 { get; set; }
    int PrivateState5 { get; set; }
    string PublicState1 { get; set; }
    string PublicState2 { get; set; }
    string PublicState3 { get; set; }
    string PublicState4 { get; set; }
    string PublicState5 { get; set; }
    void InternalBusinessLogic1(int newValue);
    void InternalBusinessLogic2(int newValue);
    void InternalBusinessLogic3(int newValue);
    void InternalBusinessLogic4(int newValue);
    void InternalBusinessLogic5(int newValue);
    void PublicBusinessLogic1();
    void PublicBusinessLogic2();
    void PublicBusinessLogic3();
    void PublicBusinessLogic4();
    void PublicBusinessLogic5();
}

public class ViewModel
    : IViewModel
{
    private int _privateState1;
    private int _privateState2;
    private int _privateState3;
    private int _privateState4;
    private int _privateState5;
    
    private readonly IViewModelRestorer _viewModelRestorer;

    public ViewModel(Func<IViewModel, IViewModelRestorer> viewModelRestorer)
    {
        _viewModelRestorer = viewModelRestorer(this);
    }

    int IViewModel.PrivateState1
    {
        get => _privateState1;
        set => _privateState1 = value;
    }

    int IViewModel.PrivateState2
    {
        get => _privateState2;
        set => _privateState2 = value;
    }

    int IViewModel.PrivateState3
    {
        get => _privateState3;
        set => _privateState3 = value;
    }

    int IViewModel.PrivateState4
    {
        get => _privateState4;
        set => _privateState4 = value;
    }

    int IViewModel.PrivateState5
    {
        get => _privateState5;
        set => _privateState5 = value;
    }

    public string PublicState1 { get; set; }
    public string PublicState2 { get; set; }
    public string PublicState3 { get; set; }
    public string PublicState4 { get; set; }
    public string PublicState5 { get; set; }
    
    private void InternalBusinessLogic1(int newValue)
    {
        // Do some work
    }
    private void InternalBusinessLogic2(int newValue)
    {
        // Do some work
    }
    private void InternalBusinessLogic3(int newValue)
    {
        // Do some work
    }
    private void InternalBusinessLogic4(int newValue)
    {
        // Do some work
    }
    private void InternalBusinessLogic5(int newValue)
    {
        // Do some work
    }
    
    void IViewModel.InternalBusinessLogic1(int newValue) => InternalBusinessLogic1(newValue);
    void IViewModel.InternalBusinessLogic2(int newValue) => InternalBusinessLogic2(newValue);
    void IViewModel.InternalBusinessLogic3(int newValue) => InternalBusinessLogic3(newValue);
    void IViewModel.InternalBusinessLogic4(int newValue) => InternalBusinessLogic4(newValue);
    void IViewModel.InternalBusinessLogic5(int newValue) => InternalBusinessLogic5(newValue);

    public void PublicBusinessLogic1()
    {
        // Do some work
    }
    public void PublicBusinessLogic2()
    {
        // Do some work
    }
    public void PublicBusinessLogic3()
    {
        // Do some work
    }
    public void PublicBusinessLogic4()
    {
        // Do some work
    }
    public void PublicBusinessLogic5()
    {
        // Do some work
    }
}
