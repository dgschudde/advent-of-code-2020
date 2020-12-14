using System.Collections.Generic;

namespace DayFourteen
{
    public class FerryProgram
    {
        public string Mask { get; set; }
        
        public IList<FerryProgramItem> ProgramItem { get; set; }
    }
}