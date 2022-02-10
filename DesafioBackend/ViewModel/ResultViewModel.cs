using System.Collections.Generic;

namespace DesafioBackend.ViewModel
{
    public class ResultViewModel
    {
        public ResultViewModel(dynamic data)
        {
            Data = data;
        }

        public ResultViewModel(bool error, string mensagem)
        {
            Error = error;
            Mensagem = mensagem;
        }      

        public dynamic Data { get;  set; }
        public string Mensagem { get;  set; } 
        public bool? Error { get;  set; }
    }
}
