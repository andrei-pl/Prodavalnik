using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavalnik.Models
{
    class Notice
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Notice(string title, string description, string image)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
        }
    }
}
