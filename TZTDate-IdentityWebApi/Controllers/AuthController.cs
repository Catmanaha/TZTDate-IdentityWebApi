using MediatR;
using Microsoft.AspNetCore.Mvc;
using TZTDate.IdentityWebApi.Data.Token.Commands;
using TZTDate.IdentityWebApi.Data.User.Commands;
using TZTDate.IdentityWebApi.Data.User.Dtos;
using TZTDate.IdentityWebApi.Filters;

namespace TZTDate.IdentityWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[ServiceFilter(typeof(ValidationFilterAttribute))]
public class AuthController : ControllerBase
{
  private readonly ISender sender;

  public AuthController(ISender sender)
  {
    this.sender = sender;
  }

  [HttpPost]
  public async Task<ActionResult> Register([FromForm]UserRegisterDto userDto)
  {
    await sender.Send(new AddNewCommand() { UserRegisterDto = userDto });

    return Ok();
  }

  [HttpPost]
  public async Task<ActionResult> Login(UserLoginDto loginDto)
  {
    var result = await sender.Send(new LoginCommand() { userLoginDto = loginDto });

    return Ok(result);
  }

  [HttpPut]
  public async Task<IActionResult> UpdateTokenAsync(UpdateTokenDto updateTokenDto)
  {
    var result = await sender.Send(new UpdateTokenCommand { UpdateTokenDto = updateTokenDto });

    if (result == null || !result.Success)
    {
      return BadRequest(result?.ErrorMessage ?? "Failed to update token.");
    }

    return Ok(new
    {
      result.AccessToken,
      result.RefreshToken
    });
  }
}
