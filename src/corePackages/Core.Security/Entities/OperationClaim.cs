using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class OperationClaim: Entity
    {
        public string Name { get; set; }

        public OperationClaim(int id,string name): this()
        {
            Id = id;
            Name = name;
        }

        public OperationClaim()
        {

        }
    }
}
