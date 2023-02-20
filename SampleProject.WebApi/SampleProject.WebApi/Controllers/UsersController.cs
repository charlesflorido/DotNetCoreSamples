using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Database;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;

namespace SampleProject.WebApi.Controllers
{
	[ApiController]
	[Route("users")]
	public class UsersController : ControllerBase
	{
		private readonly SampleDbContext _context;
		private readonly IMapper _mapper;

		public UsersController(SampleDbContext context)
		{
			_context = context;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new SampleMappingProfile());
			}));
		}

		/// <summary>
		/// Find users
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[SwaggerResponse(200, "Success", typeof(IEnumerable<User>))]
		public ActionResult Find()
		{
			var results = _context.Users.AsNoTracking();
			return Ok(results);
		}

		/// <summary>
		/// Get User by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id:guid}")]
		[SwaggerResponse(200, "Success", typeof(User))]
		[SwaggerResponse(400, "Not Found")]
		public async Task<ActionResult> GetById([FromRoute] Guid id)
		{
			var result = await _context.Users.FirstAsync(t => t.Id == id);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		/// <summary>
		/// Add user
		/// </summary>
		/// <param name="userDto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult> Add([FromBody]UserDto userDto)
		{
			var user = _mapper.Map<User>(userDto);
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return Ok(new ModifiedViewModel
			{
				Id = Convert.ToString(user.Id),
				Type = "User",
				CreatedTimestamp = user.CreatedTimestamp,
				UpdatedTimestamp = user.UpdatedTimestamp
			});
		}

		/// <summary>
		/// Update user
		/// </summary>
		/// <param name="id"></param>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPatch("{id:guid}")]
		public async Task<ActionResult> Update(
			[FromRoute] Guid id,
			[FromBody] UserDto dto
		)
		{
			var user = await _context.Users.FirstOrDefaultAsync(t => t.Id == id);

            if (user == null)
            {
                return NotFound();
            }

			user = _mapper.Map(dto, user);
			user.UpdatedTimestamp = DateTime.UtcNow;
			await _context.SaveChangesAsync();

            return Ok(new ModifiedViewModel
            {
                Id = Convert.ToString(user.Id),
                Type = "User",
                CreatedTimestamp = user.CreatedTimestamp,
                UpdatedTimestamp = user.UpdatedTimestamp
            });
        }
	}
}

