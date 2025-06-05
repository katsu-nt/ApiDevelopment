
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Model;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService _postService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetPosts()
    {
        var posts = await _postService.GetAllPosts();
        return Ok(posts);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Post>>> GetPost(int id)
    {
        var post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        await _postService.CreatePost(post);
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(int id, Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }
        var updatedPost = await _postService.UpdatePost(id, post);
        if (updatedPost == null)
        {
            return NotFound();
        }
        return Ok(post);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var deletedPost = await _postService.GetPost(id);
        if (deletedPost == null)
        {
            return NotFound();
        }

        await _postService.DeletePost(id);
        return NoContent();
    }

}
