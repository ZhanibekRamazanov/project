using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
namespace API.Entities;

    public class AppUser{

        public int Id { get;set; }



        public string UserName {get;set;}

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }





        

        public string DateOfBirth { get; set; }



        public string Email { get; set; }



        public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();




        public List<Address> Addresses {get; set;} = new List<Address>();
        


        




        


    }






