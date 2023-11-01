

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get;set; }
        public string UserName {get;set;}

        public string phoneNumberNumber {get;set;}

        public string addressStreet {get;set;}





        public string DateOfBirth { get; set; }

        public string Email { get; set; }

        public List<PhoneNumberDto> PhoneNumbers { get; set; } 

        public List<AddressDto> Addresses {get; set;} 

        
    }
}