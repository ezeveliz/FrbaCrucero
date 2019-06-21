using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Clases;

namespace FrbaCrucero.Inicio
{
    public partial class MenuPrincipal : Frame
    {
        private Usuario Usuario;
        private Dictionary<int, Func<Form>> funcDisponibles;
        private Bienvenida bienvenidaView;

        public MenuPrincipal(Usuario user, Bienvenida _bienvenidaView)
        {
            InitializeComponent();
            this.inicializarDiccFuncionalidades();
            this.bienvenidaView = _bienvenidaView;
            this.Usuario = user;
            var funcionalidades = new List<KeyValuePair< int, string>>(); //Genera una lista de funcionalidades vacias
            user.Funcionalidades.ForEach(funcinalidad => funcionalidades.Add(new KeyValuePair<int, string>(funcinalidad.Id, funcinalidad.Descripcion))); // Por cada funcionalidad de usuario la setea en una lista para agregarla al listbox 

            this.listFuncionalidades.DisplayMember = "Value"; // setea el key y value para el listbox
            this.listFuncionalidades.ValueMember = "Key";

            funcionalidades.ForEach(item => listFuncionalidades.Items.Add(item));// Agrega las funcionalidades al list box

            if (this.listFuncionalidades.Items.Count < 1) //Si no seleccione ninguna funcionalidad no puedo continuar
            {
                this.seleccionar.Enabled = false;
            }
        }

        public void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            bienvenidaView.Show();
        }

        // vuelve al inicio 
        private void volver_Click(object sender, EventArgs e)
        {
            this.MenuPrincipal_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void inicializarDiccFuncionalidades() //Para agregar las funcioens a los formularios correspondientes y sus respectivos ids
        {
            this.funcDisponibles = new Dictionary<int, Func<Form>>();
            this.funcDisponibles.Add(1, () => new AbmRol.AbmRol(this));
            this.funcDisponibles.Add(2, () => new AbmUsuario.AbmUsuario(this));
            this.funcDisponibles.Add(3, () => new AbmPuerto.AbmPuerto(this));
            this.funcDisponibles.Add(4, () => new AbmRecorrido.AbmRecorrido(this));
            this.funcDisponibles.Add(5, () => new AbmCrucero.AbmC());
            this.funcDisponibles.Add(6, () => new CompraPasajes.CompraPasajes());
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            int funcionalidadSeleccionada = ((KeyValuePair<int, string>)this.listFuncionalidades.SelectedItem).Key; //Agarra la key de la funcionalidad elegida 
            this.Hide();
            this.funcDisponibles[funcionalidadSeleccionada]().ShowDialog();//Ejecuta la funcion del diccionario
        }


    }
}
