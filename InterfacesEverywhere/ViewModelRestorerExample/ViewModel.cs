namespace InterfacesEverywhere.ViewModelRestorerExample;

public class ViewModel
{
    private int _privateState1;
    private int _privateState2;
    private int _privateState3;
    private int _privateState5;
    
    private void InternalBusienssLogic1(int newValue)
    {
        // Do some work
    }
    private void InternalBusienssLogic2(int newValue)
    {
        // Do some work
    }
    private void InternalBusienssLogic3(int newValue)
    {
        // Do some work
    }
    private void InternalBusienssLogic4(int newValue)
    {
        // Do some work
    }
    private void InternalBusienssLogic5(int newValue)
    {
        // Do some work
    }
    
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

    public void RestoreState(object state)
    {
        // Restore whole view model from saved state.
    }
}