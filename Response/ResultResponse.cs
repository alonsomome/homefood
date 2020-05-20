namespace HomeFood.Response
{
    public class ResultResponse<T>
    {
        public T Data{set;get;}
        public bool Error{set;get;}
        public string Message{set;get;}
    }
}