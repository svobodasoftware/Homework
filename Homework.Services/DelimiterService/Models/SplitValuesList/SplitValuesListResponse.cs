using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.DelimiterService.Models
{
	public class SplitValuesListResponse : ResponseBase
	{
		public List<string[]> ValuesList { get; set; }
	}
}