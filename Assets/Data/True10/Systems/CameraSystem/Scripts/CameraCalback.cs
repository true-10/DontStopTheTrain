namespace True10.CameraSystem
{
    public class CameraCalback : ICameraCallback
    {
        //camera's info
        public string Name { get => camHolder.CameraName;}
        public ICameraHolder camHolder { get; }

        public CameraCalback(ICameraHolder camHolder)
        {
            this.camHolder = camHolder;
        }
    }

}

