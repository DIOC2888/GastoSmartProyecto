using GastoSmart.Models;

public class CategoriaService
{
    private readonly List<Categoria> _categorias = new();
    private int _nextId = 1;

    public CategoriaService()
    {
        // Semillas de ejemplo (podés quitarlas si querés)
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

    public List<Categoria> ObtenerTodo()
    {
        return _categorias;
    }

    public Categoria? ObtenerPorId(int id)
    {
        return _categorias.FirstOrDefault(c => c.IdCategoria == id);
    }

    public void Agregar(Categoria categoria)
    {
        categoria.IdCategoria = _nextId++;
        _categorias.Add(categoria);
    }

    public void Actualizar(Categoria categoriaEditada)
    {
        var existente = _categorias.FirstOrDefault(c => c.IdCategoria == categoriaEditada.IdCategoria);
        if (existente == null) return;

        existente.Nombre = categoriaEditada.Nombre;
        existente.Descripcion = categoriaEditada.Descripcion;
        existente.Tipo = categoriaEditada.Tipo;
        existente.Activa = categoriaEditada.Activa;
    }

    public void Eliminar(int id)
    {
        _categorias.RemoveAll(c => c.IdCategoria == id);
    }

    public bool NombreExiste(string nombre)
    {
        return _categorias.Any(c =>
            c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public bool NombreExiste(string nombre, int idExcluir)
    {
        return _categorias.Any(c =>
            c.IdCategoria != idExcluir &&
            c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }
}