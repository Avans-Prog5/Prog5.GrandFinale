using System;

namespace TheGrandFinale.ViewModel
{
    public class RidderVM
    {
        private Ridder r;

        public RidderVM()
        {
            r = new Ridder();
        }

        public RidderVM(Ridder r)
        {
            this.r = r;
        }

        public string Naam
        {
            get { return r.Naam;  }
            set { r.Naam = value; }
        }

        internal Ridder ToModel()
        {
            return r;
        }
    }
}