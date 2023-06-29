using Blog.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Blog.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly IDbConnection _bd;
        public CategoriaRepositorio(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLLocalDB"));
        }
        public List<Categoria> GetCategorias()
        {
            var sql = "SELECT * FROM Categoria";
            return _bd.Query<Categoria>(sql).ToList();
        }
        public Categoria GetCategoria(int idCategoria)
        {
            var sql = "SELECT * FROM Categoria WHERE IdCategoria = @IdCategoria";
            return _bd.Query<Categoria>(sql, new { IdCategoria = idCategoria }).Single();
        }
        public Categoria CrearCategoria(Categoria categoria)
        {
            var sql = "INSERT INTO Categoria (Nombre, FechaCreacion) VALUES (@Nombre, @FechaCreacion); SELECT SCOPE_IDENTITY()";
            _bd.Execute(sql, new
            {
                categoria.Nombre,
                FechaCreacion = DateTime.Now
            });
            return categoria;
        }
        public Categoria ActualizarCategoria(Categoria categoria)
        {
            var sql = "UPDATE Categorias SET Nombre = @Nombre WHERE IdCategoria = @IdCategoria";
            _bd.Execute(sql, categoria);
            return categoria;
        }
        public void BorrarCategoria(int idCategoria)
        {
            var sql = "DELETE FROM Categoria WHERE IdCategoria = @IdCategoria";
            _bd.Execute(sql, new { IdCategoria = idCategoria });
        }
    }
}
