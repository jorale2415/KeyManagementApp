using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManagementApp.Models
{
    public partial class Properties
    {
        public string PropAdd { get; set; }
        public string PropCity { get; set; }
        public string PropState { get; set; }
        public string PropZip { get; set; } 
        public int OwnerId { get; set; }
        public int KeyBoxId { get; set; }
        
       /* public Owner OwnerObject { get; set; }

        public KeyBox KeyBoxObject { get; set; }*/
    }
}
