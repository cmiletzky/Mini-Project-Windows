using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// entity to represent bus
    /// </summary>
    public class Bus
    {
        private string id;
        private DateTime? start_date;
        private int km = 0;
        private int last_treat_km;
        private int gas = 0;
        private DateTime? last_treat_date = DateTime.Now;
        private bool inTreatment = false;
        private bool inRefule = false;
        private bool inDriving = false;
        bool isActive = true;


        //function get & set
        public bool IsActive { get {return isActive; } set { isActive = value; } }
       
        public string Id { get { return id; } set { id = value; } }
        public DateTime? StartDate { get { return start_date; } set { start_date = value; } }
        public int Km { get { return km; } set { km = value; } }
        public int LastTreastKm { get { return last_treat_km; } set { last_treat_km = value; } }
        public int Gas { get { return gas; } set { gas = value; } }
        public DateTime? LastTreatDate { get { return last_treat_date; } set { last_treat_date = value; } }
        public bool InTreamant { get { return inTreatment; } set { inTreatment = value; } }
        public bool InRefule { get { return inRefule; } set { inRefule = value; } }
        public bool InDriving { get { return inDriving; } set { inDriving = value; } }



        //constractor
        public Bus(string id, DateTime? start_date)
        {
            this.id = print_car_number(id);
            this.start_date = start_date;



        }

        // print the bus id with the right format
        static string print_car_number(string val)
        {
            string id_string = val.ToString();
            if (int.Parse(val) > 9999999)
            {
                return id_string.Substring(0, 3) + "-" + id_string.Substring(3, 2) + "-" + id_string.Substring(5, 3);
            }
            else
            {
                return id_string.Substring(0, 2) + "-" + id_string.Substring(2, 3) + "-" + id_string.Substring(5, 2);
            }
        }

        

    }
}
