using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Models
{
    public interface IDAO<T>
    {
        object insert(T t);
        void Update(T t);
        void Delete(int id);
        T Select(int id);
        List<T> Select();


    }
}
