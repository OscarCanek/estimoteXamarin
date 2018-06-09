namespace estimoteXamarin
{
    public interface IBluetoothHandler
    {
        void Enable();
        void Disable();
        bool IsEnabled();
    }
}