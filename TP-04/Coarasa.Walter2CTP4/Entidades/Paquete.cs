using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Entidades;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public enum EEstado
        {
            ingresado,
            en_viaje,
            entregado
        }

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.ingresado;
        }

        public void MockCicloDeVida()
        {
            do
            {
                this.InformaEstado.Invoke(this, null);
                Thread.Sleep(10000);
                if (this.Estado == EEstado.ingresado)
                {
                    this.Estado = EEstado.en_viaje;
                }
                else
                {
                    this.Estado = EEstado.entregado;
                }


            } while (this.Estado != EEstado.entregado);
            this.InformaEstado.Invoke(this, null);
            try
            {
                PaqueteDAO.Insertar(this); //LLAMA PARA INSERTAR EN LA BASE DE DATOS
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error Base de Datos");
                //throw new TrackingIdRepetidoException(e.Message);
            }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TrackingID == p2.TrackingID)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            if (p1 == p2)
            {
                return false;
            }
            return true;
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1} ({2})", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega, ((Paquete)elemento).Estado);
        }
    }
}
