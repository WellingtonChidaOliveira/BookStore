namespace BookStore.Shared.Utils
{

   public static class TypesTel
    {
        public const string Celular = "Celular";
        public const string Residencial = "Residencial";
        public const string Comercial = "Comercial";


        public static List<string> GetAllTypes()
        {
            return new List<string>
            {
                Celular,
                Residencial,
                Comercial
            };
        }
    }
    

}
