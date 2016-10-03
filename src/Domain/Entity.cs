using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// 泛型基类实体
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class Entity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public TPrimaryKey Id { get; set; }
    }
}
