namespace PruebaFamiliar.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        //[StringLength(maximunLength: 50)]
        //[PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
 