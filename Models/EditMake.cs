namespace SimplyHorsePower.Models
{
    public class EditMake
    {
        public int Id { get; set; }
        public void EditAMake(Make make)
        {           
            make.MakeId = make.MakeId;
            make.MakeName = make.MakeName;
        }

    }
}
