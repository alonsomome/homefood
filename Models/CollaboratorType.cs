using System;
using System.Collections.Generic;

namespace HomeFood.Models
{
    public partial class CollaboratorType
    {
        public CollaboratorType()
        {
            Collaborator = new HashSet<Collaborator>();
        }

        public int CollaboratorTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Collaborator> Collaborator { get; set; }
    }
}
