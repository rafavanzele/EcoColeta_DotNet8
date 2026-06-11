namespace EcoColeta.Api.Configurations
{
    public class RecursoNaoEncontradoException : Exception
    {
        public RecursoNaoEncontradoException(string mensagem) : base(mensagem)
        {
        }
    }
}