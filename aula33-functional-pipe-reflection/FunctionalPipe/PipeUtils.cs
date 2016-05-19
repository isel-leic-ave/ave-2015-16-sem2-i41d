using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalPipe
{
    public static class PipeUtils
    {
        /// <summary>
        /// Retorna uma nova instância de Func<T, Rafter> cuja execução é igual à
        /// chamada de self seguida de after.
        /// O resultado de self é passado como argumento a after.
        /// </summary>
        public static Func<T, Rafter> AndThen<T, Rself, Rafter>(
            this Func<T, Rself> self,
            Func<Rself, Rafter> after)
        {
            return arg => after(self(arg));
        }

        /// <summary>
        /// Retorna uma nova instância de Func<T, T> cuja execução é igual à 
        /// chamada encadeada de todos os métodos estáticos compatíveis com 
        /// Func<T, T> do assembly localizado em path.
        /// Os métodos são encadeados através da função AndThen.
        /// </summary>
        public static Func<T, T> ChainMethodsV1<T>(string path)
        {
            Func<T, T> res = null;
            Assembly a = Assembly.LoadFrom(path);
            foreach (Type t in a.GetTypes())
            {
                foreach (MethodInfo m in t.GetMethods())
                {
                    if (m.IsStatic && IsCompatible<T>(m)) { 
                        Func<T, T> h = arg => (T) m.Invoke(null, new object[1]{arg});
                        res = res == null ? h : res.AndThen(h);
                    }
                }
            }
            return res;    
        }

        public static Func<T, T> ChainMethodsV2<T>(string path)
        {
            Assembly a = Assembly.LoadFrom(path);
            return a
                .GetTypes()                                    // IEnumerable<Type>
                .SelectMany(t => t.GetMethods())               // IEnumerable<MethodInfo>
                .Where(m => m.IsStatic && IsCompatible<T>(m))  // IEnumerable<MethodInfo>
                .Aggregate<MethodInfo, Func<T, T>>(
                    p => p,
                    (prev, curr) => prev.AndThen(arg => (T)curr.Invoke(null, new object[1] { arg })));
        }

        public static Func<T, T> ChainMethodsV3<T>(string path)
        {
            Assembly a = Assembly.LoadFrom(path);
            return a
                .GetTypes()                                    // IEnumerable<Type>
                .SelectMany(t => t.GetMethods())               // IEnumerable<MethodInfo>
                .Where(m => m.IsStatic && IsCompatible<T>(m))  // IEnumerable<MethodInfo>
                .Aggregate<MethodInfo, Func<T, T>>(
                    p => p,
                    (prev, curr) => prev.AndThen((Func<T, T>)Delegate.CreateDelegate(typeof(Func<T, T>), curr)));
        }

        static bool IsCompatible<T>(MethodInfo m) {
            if (!typeof(T).IsAssignableFrom(m.ReturnType)) return false; // covariante => o tipo de retorno pode ser derivado
            ParameterInfo[] ps = m.GetParameters();
            if (ps.Length != 1) return false;
            return ps[0].ParameterType.IsAssignableFrom(typeof(T)); // contravariante => aceita parametro de tipo base
            // return ps[0].ParameterType == typeof(T);
        }

        /// <summary>
        /// Retorna uma nova instância de Func<T, T> cuja execução é igual à 
        /// chamada encadeada de todos os métodos estáticos compatíveis com 
        /// Func<T, T> do assembly localizado em path.
        /// Cada método é executado com o validador anotado, caso exista.
        /// </summary>
        public static Func<T, T> ChainMethodsValidators<T>(string path)
        {
            throw new NotImplementedException();
        }

    }
}
