namespace True10.CameraSystem
{
    public class CameraCallback : ICameraCallback
    {
        //camera's info
        public string Name { get => camHolder.CameraName;}
        public ICameraHolder camHolder { get; }

        public CameraCallback(ICameraHolder camHolder)
        {
            this.camHolder = camHolder;
        }
    }

}

