﻿using Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers;

public static class ErrorResultExtentions
{
    public static List<ErrorModel> ToErrorModel(this IEnumerable<ValidationFailure> failures)
    {
        var output = new List<ErrorModel>();
        output.AddRange(failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .Select((x, y) => new ErrorModel
            {
                ErrorCode = x.Key,
                ErrorMessage = GetErrorMessage(x),
            }));

        return output;
    }

    private static string GetErrorMessage(IGrouping<string, string> x)
    {
        var output = "";
        foreach (var item in x)
        {
            output += $"{item}{Environment.NewLine}";
        }
        return output;
    }
}
