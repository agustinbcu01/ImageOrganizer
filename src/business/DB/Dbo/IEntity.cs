using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DB.Dbo
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
