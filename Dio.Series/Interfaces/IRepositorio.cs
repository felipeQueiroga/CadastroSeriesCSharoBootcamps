using System;
using System.Collections.Generic;
using System.Text;

namespace Dio.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        public void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
