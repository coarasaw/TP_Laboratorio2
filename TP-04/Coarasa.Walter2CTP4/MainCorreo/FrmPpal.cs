﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        Paquete paquete;
        
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblEstadoIngresado_Click(object sender, EventArgs e)
        {

        }
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            foreach (Paquete aux in correo.Paquetes)
            {
                switch (aux.Estado)
                {
                    case Paquete.EEstado.ingresado:
                        if (!lstEstadoIngresado.Items.Contains(aux.ToString()))
                            lstEstadoIngresado.Items.Add(aux.ToString());
                        break;
                    case Paquete.EEstado.en_viaje:
                        if (!lstEstadoEnViaje.Items.Contains(aux.ToString()))
                        {
                            lstEstadoEnViaje.Items.Add(aux.ToString());
                            lstEstadoIngresado.Items.Clear();
                        }
                        break;
                    case Paquete.EEstado.entregado:
                        if (!lstEstadoEntregado.Items.Contains(aux.ToString()))
                        {
                            lstEstadoEntregado.Items.Add(aux.ToString());
                            lstEstadoEnViaje.Items.Clear();
                        }
                        break;
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                if (elemento != null)
                {
                    if (elemento is Paquete)
                    {
                        rtbMostrar.Text = ((Paquete)elemento).ToString();
                    }
                    else if (elemento is Correo)
                    {

                        rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                    }
                    string nombreArchivo = "salida";
                    rtbMostrar.Text.Guardar(nombreArchivo);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarTodos_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
    }
}
