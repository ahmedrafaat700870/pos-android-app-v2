using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.DayShift
{
    public class WorkShift
    {
        public WorkShift()
        {
            UserWorkShifts = new HashSet<UserWorkShift>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool WorkShiftStatus_isCompliated { get; set; } // cmpliate , not compliate.
        public int ShiftCount { get; set; } = 0;
        public virtual ICollection<UserWorkShift> UserWorkShifts { get; set; }


    }
}
