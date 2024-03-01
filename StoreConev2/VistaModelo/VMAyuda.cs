using StoreConev2.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreConev2.VistaModelo
{
    public class VMAyuda : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private string _opcion;
        private string _imagen;

        #endregion
        #region CONSTRUCTOR
        public VMAyuda(INavigation navigation)
        {
            Navigation = navigation;
            Imagen = "https://i.ibb.co/yfbXVxy/pinchefondo.jpg";

        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string Opcion
        {
            get { return _opcion; }
            set { SetValue(ref _opcion, value); }
        }
        public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }
        //ESTE METODO DEPENIENDO DE LO QUE ELIGA EL USUARIO ES LA IMAGEN QUE DEBE SALIR
        public void MostrarImagen()
        {
            
            
            
                switch (Opcion)
                {
                    case "1A":
                        Imagen = "https://i.ibb.co/6NNmzDw/1A.jpg";
                    
                        break;

                    case "1a":
                        Imagen = "https://i.ibb.co/6NNmzDw/1A.jpg";
                        break;
                    case "1B":
                        Imagen = "https://i.ibb.co/pZnRTLn/1B.jpg";
                        break;

                    case "1b":
                        Imagen = "https://i.ibb.co/pZnRTLn/1B.jpg";
                        break;
                    case "1C":
                        Imagen = "https://i.ibb.co/3SxsXGy/1C.jpg";
                        break;

                    case "1c":
                        Imagen = "https://i.ibb.co/3SxsXGy/1C.jpg";
                        break;
                    case "1D":
                        Imagen = "https://i.ibb.co/3YW0X26/1D.jpg";
                        break;

                    case "1d":
                        Imagen = "https://i.ibb.co/3YW0X26/1D.jpg";
                        break;
                    case "2A":
                        Imagen = "https://i.ibb.co/xqf4ns0/2A.jpg";
                        break;

                    case "2a":
                        Imagen = "https://i.ibb.co/xqf4ns0/2A.jpg";
                        break;
                    case "2B":
                        Imagen = "https://i.ibb.co/0ZY4hgL/2Bjpg.jpg";
                        break;

                    case "2b":
                        Imagen = "https://i.ibb.co/0ZY4hgL/2Bjpg.jpg";
                        break;
                    case "2C":
                        Imagen = "https://i.ibb.co/7CgDBWs/2C.jpg";
                        break;

                    case "2c":
                        Imagen = "https://i.ibb.co/7CgDBWs/2C.jpg";
                        break;
                    case "2D":
                        Imagen = "https://i.ibb.co/ZgzptJR/2D.jpg";
                        break;

                    case "2d":
                        Imagen = "https://i.ibb.co/ZgzptJR/2D.jpg";
                        break;
                    case "3A":
                        Imagen = "https://i.ibb.co/TWh6t93/3A.jpg";
                        break;

                    case "3a":
                        Imagen = "https://i.ibb.co/TWh6t93/3A.jpg";
                        break;
                    case "3B":
                        Imagen = "https://i.ibb.co/1rdYgGF/3B.jpg";
                        break;

                    case "3b":
                        Imagen = "https://i.ibb.co/1rdYgGF/3B.jpg";
                        break;
                    case "3C":
                        Imagen = "https://i.ibb.co/C13s36G/3C.jpg";
                        break;

                    case "3c":
                        Imagen = "https://i.ibb.co/C13s36G/3C.jpg";
                        break;
                    case "3D":
                        Imagen = "https://i.ibb.co/gwhyrG4/3D.jpg";
                        break;

                    case "3d":
                        Imagen = "https://i.ibb.co/gwhyrG4/3D.jpg";
                        break;
                    case "4A":
                        Imagen = "https://i.ibb.co/54wTpYF/4A.jpg";
                        break;

                    case "4a":
                        Imagen = "https://i.ibb.co/54wTpYF/4A.jpg";
                        break;
                    case "4B":
                        Imagen = "https://i.ibb.co/LdkTs1Y/4B.jpg";
                        break;

                    case "4b":
                        Imagen = "https://i.ibb.co/LdkTs1Y/4B.jpg";
                        break;
                    case "4C":
                        Imagen = "https://i.ibb.co/mXjYpSX/4C.jpg";
                        break;

                    case "4c":
                        Imagen = "https://i.ibb.co/mXjYpSX/4C.jpg";
                        break;
                    case "4D":
                        Imagen = "https://i.ibb.co/drCRJTr/4D.jpg";
                        break;

                    case "4d":
                        Imagen = "https://i.ibb.co/drCRJTr/4D.jpg";
                        break;
                    default:
                        Imagen = "https://i.ibb.co/4VR5TN5/ufff.jpg";
                        break;

                }
            
            
        }
        public ICommand IrPaginaComand => new Command(async () => await IrPagina());

        private async Task IrPagina()
        {
            switch (Opcion.ToUpper())
            {
                case "1A":
                case "2A":
                case "3A":
                case "4A":
                    await Navigation.PushAsync(new SeccionA());
                    break;
                case "1B":
                case "2B":
                case "3B":
                case "4B":

                    await Navigation.PushAsync(new SeccionB());
                    break;
                case "1C":
                case "2C":
                case "3C":
                case "4C":

                    await Navigation.PushAsync(new SeccionC());
                    break;
                case "1D":
                case "2D":
                case "3D":
                case "4D":

                    await Navigation.PushAsync(new SeccionD());
                    break;
                // Otros casos...
                default:
                    // Página por defecto o manejo de error
                    break;
            }
        }
        public async Task IrSeccionA()
        {
            SeccionA  seccionA = new SeccionA();
            await Navigation.PushAsync(new SeccionA());
        }
        public async Task IrNotificaciones()
        {
            await Navigation.PushAsync(new Notificaciones());
        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand MostrarImagenComand => new Command(MostrarImagen);
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
        public ICommand B => new Command(async () => await IrSeccionA());


        #endregion
    }
}
