namespace TFGHotel.DTO
{
    public class DoChangeUserPasswordDTO
    {
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
