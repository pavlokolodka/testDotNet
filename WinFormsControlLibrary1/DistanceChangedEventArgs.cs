namespace WinFormsControlLibrary1
{
    public class DistanceChangedEventArgs : EventArgs
    {
        public double NewDistance { get; }

        public DistanceChangedEventArgs(double newDistance)
        {
            NewDistance = newDistance;
        }
    }

}
