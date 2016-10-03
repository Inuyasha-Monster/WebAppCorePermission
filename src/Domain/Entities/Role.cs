using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// 角色实体
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 角色名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        public virtual User CreateUser { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
