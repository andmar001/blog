using Blog.Models;

namespace Blog.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Categoria GetCategoria(int idCategoria);
        List<Categoria> GetCategorias();
        Categoria CrearCategoria(Categoria categoria);
        Categoria ActualizarCategoria(Categoria categoria);
        void BorrarCategoria(int idCategoria);
        List<Categoria> GetAllStored(); 
    }
}
