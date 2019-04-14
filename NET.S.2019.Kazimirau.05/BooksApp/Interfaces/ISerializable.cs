namespace BooksApp.Interfaces
{
    interface ISerializable
    {
        void ToXML();
        void ToJSON();
    }
}
