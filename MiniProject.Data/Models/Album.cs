using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MiniProject.Data.Models
{
    public class Album
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
