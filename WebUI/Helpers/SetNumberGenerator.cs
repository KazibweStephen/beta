using System;

namespace WebUI.Helpers
{
    public class SetNumberGenerator
    {
        private static int _currentSetNumber;
        private static String _monthFormats;
        public static int GetCurrentSetNumber
        {
            get
            {
                var currentDate = DateTime.Now;     
                
                {
                     _monthFormats =Convert.ToString(currentDate.Month); 
                }
                _currentSetNumber =
                    Int32.Parse((String.Format("{0}{1}{2}", currentDate.Year, currentDate.Month, currentDate.Day)));
               // _currentSetNumber = Int32.Parse(( currentDate.Year+_monthFormats+currentDate.Day));

                return _currentSetNumber;
            }

            set
            {
                _currentSetNumber = value;
            }

        }

        
    }
}