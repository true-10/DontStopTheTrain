namespace True10.CameraSystem
{
    public class CameraCallback : ICameraCallback
    {
        //camera's info
        public string Name { get => CameraHolder.CameraName;}
        public ICameraHolder CameraHolder { get; }

        public CameraCallback(ICameraHolder camHolder)
        {
            this.CameraHolder = camHolder;
        }
    }

}

