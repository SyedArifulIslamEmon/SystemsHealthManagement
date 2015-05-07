using System;
using System.Linq.Expressions;

namespace Integra.Dominio.Teste.Helpers
{
    public static class ExtensoesDeTipoGenerico
    {
        public static void Setar<T, TW>(this T tipo, Expression<Func<T,TW>> propriedade, TW novoValor)
        {
            var memberExpression = propriedade.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Expression deve ser do tipo MemberExpression", "propriedade");
            var nomeDaPropriedade = memberExpression.Member.Name;
            typeof(T).GetProperty(nomeDaPropriedade).SetValue(tipo, novoValor, null);
        }
    }
}