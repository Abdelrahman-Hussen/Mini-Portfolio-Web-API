﻿using Portfolio.Domain.Features.User.Models;
using Portfolio.Domain.Specification;

namespace Portfolio.Application.Features.Auth
{
    internal class RefreshTokenSpecification : BaseSpecification<RefreshToken>
    {
        public static RefreshTokenSpecification GetByToken(string token)
        {
            var spec = new RefreshTokenSpecification();

            spec.AddCriteria(x => x.Token == token);

            spec.AddInclude(new List<string> { nameof(RefreshToken.User) });

            return spec;
        }

        public static RefreshTokenSpecification GetByUserId(string UserId)
        {
            var spec = new RefreshTokenSpecification();

            spec.AddCriteria(x => x.UserId == UserId);

            return spec;
        }
    }
}
