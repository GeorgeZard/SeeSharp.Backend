﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeeSharp.Application.Features.BlogPosts.Commands.CreateBlogPost;
using SeeSharp.Application.Features.BlogPosts.Commands.DeleteBlogPost;
using SeeSharp.Application.Features.BlogPosts.Commands.UpdateBlogPost;
using SeeSharp.Application.Features.BlogPosts.Queries;
using SeeSharp.Application.Features.BlogPosts.Queries.GetBlogPostByIdQuery;
using SeeSharp.Application.Features.BlogPosts.Queries.GetBlogPostsQuery;
using SeeSharp.Application.Features.BlogPosts.Queries.GetBlogPostWithParametersQuery;

namespace SeeSharp.Api.Controllers.v1;
[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]")]
public class BlogPostsController : ControllerBase
{
	private readonly IMediator _mediator;

	public BlogPostsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<List<BlogPostDto>> Get()
	{
		return await _mediator.Send(new GetBlogPostsQuery());
	}

	[HttpGet("with-parameters")] // Use a different route template
	public async Task<List<BlogPostDto>> GetByParameters([FromQuery] BlogPostsQueryParameters queryParameters)
	{
		return await _mediator.Send(new GetBlogPostsWithParametersQuery(queryParameters));
	}

	[HttpGet("{id:guid}")]
	public async Task<BlogPostDto> Get(Guid id)
	{
		return await _mediator.Send(new GetBlogPostByIdQuery(id));
	}

	[Authorize("Administrator")]
	[HttpPost]
	public async Task<Guid> CreateBlogPost(CreateBlogPostCommand command)
	{
		return await _mediator.Send(command);
	}

	[Authorize("Administrator")]
	[HttpPut("{id:guid}")]
	public async Task<IResult> UpdateBlogPost(Guid id, UpdateBlogPostCommand command)
	{
		if (id != command.Id) return Results.BadRequest();
		await _mediator.Send(command);
		return Results.NoContent();
	}

	[Authorize("Administrator")]
	[HttpDelete("{id:guid}")]
	public async Task<IResult> DeleteBlogPost(Guid id)
	{
		await _mediator.Send(new DeleteBlogPostCommand(id));
		return Results.NoContent();
	}
}


