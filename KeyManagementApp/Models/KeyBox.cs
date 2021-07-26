using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManagementApp.Models
{
    public partial class KeyBox
    {
        public string KeyBoxName { get; set; }
        public string KeyBoxLocation { get; set; }
        public int KeyBoxSize { get; set; }

        public string BoxName { get => KeyBoxName; }
    }
}
