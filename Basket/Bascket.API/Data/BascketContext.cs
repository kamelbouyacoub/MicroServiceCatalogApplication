using Bascket.API.Data.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bascket.API.Data
{
    public class BascketContext : IBascketContext
    {
        private readonly ConnectionMultiplexer _redisConnection;

        public BascketContext(ConnectionMultiplexer redisConnection)
        {
            this._redisConnection = redisConnection;
            Redis = redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
