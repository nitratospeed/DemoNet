using DemoNet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoNet.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioEntity>> List();
        Task Insert(UsuarioEntity entity);
    }
}
