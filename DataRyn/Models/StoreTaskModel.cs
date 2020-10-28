using System;
using System.Collections.Generic;
using System.Text;

namespace DataRyn.Models
{
    public class StoreTaskModel
    {

        public string week_no { get; set; }
        public string week_date { get; set; }
        public string store_name { get; set; }
        public string store_address { get; set; }
        public string coding_type { get; set; }
        public string Task_State { get; set; }

        public bool txtStart
        {
            get
            {
                switch (Task_State)
                {
                    case "Not Started":
                        return true;
                   
                    default:
                        return false;
                }
            }
        }

        public string roundText
        {
            get
            {
                switch (Task_State)
                {
                    case "Not Started":
                        return "5";

                    default:
                        return "1";
                }
            }
        }
        public string bgColor
        {
            get
            {
                switch (Task_State)
                {
                    case "Not Started":
                        return "#32CD32";

                    default:
                        return "#D3D3D3";
                }
            }
        }

      

    }
}
