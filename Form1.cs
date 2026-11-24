using System.ComponentModel;

namespace CrudProductos
{
    public partial class Form1 : Form
    {
        private BindingList<Producto> productos = new();
        private int siguienteId = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void ActualizarGrid()
        {
            if (dgvProductos.DataSource == null)
                dgvProductos.DataSource = productos;
            else
                dgvProductos.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var p = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
            txtNombre.Text = p.Nombre;
            txtPrecio.Text = p.Precio.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
       !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Escribe un nombre y un precio válido.");
                return;
            }

            // Agrega el producto con un Id automático
            productos.Add(new Producto { Id = siguienteId++, Nombre = txtNombre.Text, Precio = precio });
            ActualizarGrid();
            Limpiar();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Revisa que haya un producto seleccionado en la tabla
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }

            // Valida el nombre y el precio
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Escribe un nombre y un precio válido.");
                return;
            }

            // Toma el producto seleccionado y actualiza sus datos
            var p = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            p.Nombre = txtNombre.Text;
            p.Precio = precio;
            dgvProductos.Refresh();
            Limpiar();
        }
    }
}
