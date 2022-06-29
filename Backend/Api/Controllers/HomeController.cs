using Api.DTOs;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IMapper mapper;

    public HomeController(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await userService.GetAll();

        var appUser = mapper.Map<IEnumerable<GetUserDTO>>(users);


        return Ok(appUser);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string userid)
    {
        await userService.Get(userid);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateUserDTO createUserDTO)
    {
         
        var appUser = mapper.Map<AppUser>(createUserDTO);

        if (createUserDTO.Image != null)
        {
            await userService.Create(appUser, createUserDTO.Password);
            using (var stream = new FileStream("images/" + appUser.Image, FileMode.CreateNew))
            {
                await createUserDTO.Image.CopyToAsync(stream);
            }
        }
        else
        {
            await userService.Create(appUser, createUserDTO.Password);
        }
        return Ok(appUser);
    }


    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] string userid)
    {
        await userService.Delete(userid);
        return Ok();
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateUserDTO updateUserDTO)
    {
        AppUser appUser = new AppUser();

        await userService.Update(appUser);
        return Ok();
    }

}
