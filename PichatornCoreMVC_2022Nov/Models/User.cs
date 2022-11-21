using System.ComponentModel;

namespace PichatornCoreMVC_2022Nov.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Type { get; set; }
        public int ProvinceId { get; set; }


        //? is a Nullable type
    }
}
