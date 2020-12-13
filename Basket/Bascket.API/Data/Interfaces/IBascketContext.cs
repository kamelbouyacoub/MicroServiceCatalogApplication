using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bascket.API.Data.Interfaces
{
    public interface IBascketContext
    {
        IDatabase Redis { get; }
    }
}
