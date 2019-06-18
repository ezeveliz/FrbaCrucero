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
    public partial class MenuPrincipal : Form
    {
        
        public void MenuPrincipal_Load(object sender, EventArgs e)
        {
        
        }

        private Usuario Usuario;
        private Dictionary<int, Func<Form>> funcDisponibles;

        public MenuPrincipal(Usuario user)
        {
            InitializeComponent();
            inicializarDiccFuncionalidades();
            this.Usuario = user;
            var funcionalidades = new List<KeyValuePair< int, string>>(); //Genera una lista de funcionalidades vacias
            user.Funcionalidades.ForEach(funcinalidad => funcionalidades.Add(new KeyValuePair<int, string>(funcinalidad.Id, funcinalidad.Nombre))); // Por cada funcionalidad de usuario la setea en una lista para agregarla al listbox 

            this.listFuncionalidades.DisplayMember = "Value"; // setea el key y value para el listbox
            this.listFuncionalidades.ValueMember = "Key";

            funcionalidades.ForEach(item => listFuncionalidades.Items.Add(item));// Agrega las funcionalidades al list box

            if (this.listFuncionalidades.Items.Count < 1) //Si no seleccione ninguna funcionalidad no puedo continuar
            {
                this.seleccionar.Enabled = false;
            }


        }

        // vuelve al inicio 
        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            new Bienvenida().Show();
        }

        private void inicializarDiccFuncionalidades() //Para agregar las funcioens a los formularios correspondientes y sus respectivos ids
        {
            this.funcDisponibles = new Dictionary<int, Func<Form>>();
            this.funcDisponibles.Add(5, () => new AbmCrucero.AbmC() );
           
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            int funcionalidadSeleccionada = ((KeyValuePair<int, string>)this.listFuncionalidades.SelectedItem).Key; //Agarra la key de la funcionalidad elegida 
            this.funcDisponibles[funcionalidadSeleccionada]().Show();//Ejecuta la funcion del diccionario
        }


    }
}
