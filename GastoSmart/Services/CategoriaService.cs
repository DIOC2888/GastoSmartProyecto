using GastoSmart.Models;

public class CategoriaService
{
    // Lista interna que guarda todas las categorías creadas por el usuario.
    // Funciona como nuestra "base de datos" en memoria.
    private readonly List<Categoria> _categorias = new();

    // Contador usado para generar IDs autoincrementales.
    private int _nextId = 1;

    public CategoriaService()
    {
        // Categorías de ejemplo cargadas al iniciar la aplicación.
        // Podés eliminarlas si ya no deseás valores predeterminados.
        Agregar(new Categoria
        {
            Nombre = "Alimentación",
            Descripcion = "Comidas, snacks, etc.",
            Tipo = "Gasto",
            Activa = true
        });

        Agregar(new Categoria
        {
            Nombre = "Beca",
            Descripcion = "Ingresos por beca",
            Tipo = "Ingreso",
            Activa = true
        });
    }

    // Devuelve la lista completa de categorías.
    public List<Categoria> ObtenerTodo()
    {
        return _categorias;
    }

    // Busca una categoría según su Id. Devuelve null si no existe.
    public Categoria? ObtenerPorId(int id)
    {
        return _categorias.FirstOrDefault(c => c.IdCategoria == id);
    }

    // Agrega una nueva categoría asignándole un ID único.
    public void Agregar(Categoria categoria)
    {
        categoria.IdCategoria = _nextId++;
        _categorias.Add(categoria);
    }

    // Actualiza los datos de una categoría previamente existente.
    public void Actualizar(Categoria categoriaEditada)
    {
        var existente = _categorias.FirstOrDefault(c => c.IdCategoria == categoriaEditada.IdCategoria);
        if (existente == null) return;

        existente.Nombre = categoriaEditada.Nombre;
        existente.Descripcion = categoriaEditada.Descripcion;
        existente.Tipo = categoriaEditada.Tipo;
        existente.Activa = categoriaEditada.Activa;
    }

    // Elimina una categoría usando su Id.
    public void Eliminar(int id)
    {
        _categorias.RemoveAll(c => c.IdCategoria == id);
    }

    // Verifica si ya existe una categoría con el mismo nombre.
    // Se usa al crear una nueva categoría.
    public bool NombreExiste(string nombre)
    {
        return _categorias.Any(c =>
            c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    // Verifica si existe una categoría con el mismo nombre,
    // excluyendo una categoría específica (por ejemplo, durante la edición).
    public bool NombreExiste(string nombre, int idExcluir)
    {
        return _categorias.Any(c =>
            c.IdCategoria != idExcluir &&
            c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }
}