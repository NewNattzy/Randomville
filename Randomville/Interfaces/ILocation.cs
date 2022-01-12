using System;


namespace Interfaces
{

    public interface ILocation
    {

        public string Status { get; set; }
        public int Danger { get; set; }


        public void Destroy();
        public void Curse();
        public void Improve();

    }

}