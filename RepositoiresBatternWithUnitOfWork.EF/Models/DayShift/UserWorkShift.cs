using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.DayShift
{

    public class UserWorkShift
    {

        public int Id { get; set; }

        [AllowNull]
        public int AccountsUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool ShiftStatus_isComplitaed { get; set; } = false;
        public string MaxAddress { get; set; } = null!;
        public string FromDevice { get; set; } = null!;
        public int? WorkShiftId { get; set; }

        public int OrderCount { get; set; } = 0;
        public virtual AccountsUser AccountsUser { get; set; } = null!;
        public virtual WorkShift WorkShift { get; set; } = null!;
    }
}
