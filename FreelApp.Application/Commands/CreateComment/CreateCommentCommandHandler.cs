﻿using FreelApp.Core.Entities;
using FreelApp.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly FreelAppDbContext _dbContext;
        public CreateCommentCommandHandler(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
