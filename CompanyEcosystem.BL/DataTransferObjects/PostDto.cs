using CompanyEcosystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public long Mark { get; set; }
        public DateTime Create { get; set; }

        public int LocationId { get; set; }
    }
}
