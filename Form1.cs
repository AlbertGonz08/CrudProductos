namespace CrudProductos
{
    public partial class Form1 : Form
    {
        private List<Producto> productos = new();
        private int siguienteId = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void ActualizarGrid()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
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
    }
}
