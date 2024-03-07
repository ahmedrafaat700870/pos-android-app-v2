using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Async
{
    [Table("Async")]
    [PrimaryKey("Id")]
    public class Async_Table
    {
        public int Id { get; set; }
        public DateTime? Last_Async { get; set; }
        public bool Is_First_Tiem { get; set; } = false;

    }
}
