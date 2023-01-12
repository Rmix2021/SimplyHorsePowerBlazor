using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyHorsePower.Data;

namespace SimplyHorsePower.Models
{
    public class EditCustomerBuild
    {
        public int Id { get; set; }

        public void EditAProduct(CustomerBuild customerBuild)
        {
            customerBuild.CustomerName = customerBuild.CustomerName;
            customerBuild.CustomerBuildTitle = customerBuild.CustomerBuildTitle;
            customerBuild.CustomerBuildDescription = customerBuild.CustomerBuildDescription;
        
        }
    }
}
