using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();          // SE CONFIGURA LA CONECCION (EN ACCESO DATOS)
            
            try
            {
                datos.setConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca, A.IdCategoria, C.Descripcion Categoria, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.Id = C.Id AND  A.Id = M.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    //SE CREAO UN OBJETO AUXILIAR PARA CARGALO EN LA LECTURA Y SE AGRUEGA EN LA LSITA 

                    Articulo aux = new Articulo();
                    
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //idMarca
                    //idCategoria

                    aux.categoria = new Categoria();
                    aux.categoria.ID = (int)(datos.Lector["IdMarca"]);
                    aux.categoria.Descripcion = (string)datos.Lector["Marca"];

                    aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
