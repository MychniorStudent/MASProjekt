namespace TransportAppAPI.Models
{
    public class MyEntity
    {
        private int _myPrivateField;

        public int Id { get; set; }

        // Public property exposing the private field
        public int MyProperty
        {
            get => _myPrivateField;
            set => _myPrivateField = value;
        }
    }
}
