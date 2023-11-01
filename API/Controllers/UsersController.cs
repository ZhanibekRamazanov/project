using System.Security.Cryptography;
using System.Text;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers;

[Authorize]

public class UsersController: BaseApiController
{
    

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;


    public UsersController(IUserRepository userRepository, IMapper mapper, DataContext dataContext)
    {
            _mapper = mapper;
            _userRepository = userRepository;
            _dataContext = dataContext;


    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAsync();


        return Ok(users);

    }



    [HttpGet]
    [Route("{id:}")]
    public async Task<ActionResult<MemberDto>> GetUser(int id)
    {
        return await _userRepository.GetMemberAsync(id);


    }

    [HttpPut]
    [Route("{id:}")]

    public async Task<IActionResult> UpdateMember(int id, MemberDto updateMemberRequest){
        var member = await _dataContext.Users.FindAsync(id);
        var address = await _dataContext.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        var phone = await _dataContext.PhoneNumbers.FirstOrDefaultAsync(p => p.Id == id);

        if(member == null){
            return NotFound();
        }
        member.UserName = updateMemberRequest.UserName;
        member.DateOfBirth = updateMemberRequest.DateOfBirth;
        member.Email = updateMemberRequest.Email;
        phone.Number = updateMemberRequest.phoneNumberNumber;
        address.Street = updateMemberRequest.addressStreet;



        await _dataContext.SaveChangesAsync();

        return Ok(member);

    }

    [HttpDelete]
    [Route("{id:}")]

    public async Task<IActionResult> DeleteMember(int id){
        var member = await _dataContext.Users.FindAsync(id);

        if(member == null){
            return NotFound();
        }

        _dataContext.Users.Remove(member);
        await _dataContext.SaveChangesAsync();

        return Ok(member);


    }
[HttpPost]
public async Task<IActionResult> CreateMember(MemberDto memberDto)
{




    // Преобразуйте MemberDto в AppUser
    var user = new AppUser
    {
        UserName = memberDto.UserName,
        DateOfBirth = memberDto.DateOfBirth,
        Email = memberDto.Email,
        PhoneNumbers = memberDto.PhoneNumbers.Select(p => new PhoneNumber { Number = p.Number, IsMain = p.IsMain }).ToList(),
        Addresses = memberDto.Addresses.Select(a => new Address { Street = a.Street, IsMain = a.IsMain }).ToList()


    };

    // Добавьте нового пользователя в контекст базы данных
    _dataContext.Users.Add(user);

    // Сохраните изменения в базе данных
    await _dataContext.SaveChangesAsync();

    // Верните созданного пользователя в качестве ответа
    return Ok(user);
}



    


}
