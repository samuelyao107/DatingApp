﻿
using System.Security.Claims;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;
  public UsersController(IUserRepository userRepository, IMapper mapper)
  {
     _mapper = mapper;
     _userRepository = userRepository;
 }


 [HttpGet]
 public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() 
 {
   var users = await _userRepository.GetMemberAsync();

   return Ok(users);

   
 }
 
 [HttpGet("{username}")] // /api/users/2
 public async  Task<ActionResult<MemberDto>> GetUser(string username)
 {
    return await  _userRepository.GetMemberAsync(username);
   
 }

 [HttpPut]
 public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
 {
   var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
   var user = await _userRepository.GetUserBYUsernameAsync(username);
   if(user==null) return NotFound();
   _mapper.Map(memberUpdateDto, user);
   if(await _userRepository.SaveAllAsync()) return NoContent();

   return BadRequest("Failed to update user");
 }


}
