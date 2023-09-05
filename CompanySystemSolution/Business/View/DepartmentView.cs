using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.SharedFiles;


namespace Business.View
{
    
    public class DepartmentView : TrackingData
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}


