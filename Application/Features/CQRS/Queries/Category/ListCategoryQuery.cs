﻿using Application.Dtos.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries;

public class ListCategoryQuery : IRequest<List<CategoryListDto>>
{
}
