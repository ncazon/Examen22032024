namespace WebApplication3.Models
{
  

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
    }
    public class Elemento
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
