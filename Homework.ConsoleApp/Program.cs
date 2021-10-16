using Homework.Data.Repositories.DelimiterRepository;
using Homework.Data.Repositories.DelimiterRepository.Implementation;
using Homework.Data.Repositories.FileRepository;
using Homework.Data.Repositories.FileRepository.Implementation;
using Homework.Data.Repositories.RecordRepository;
using Homework.Data.Repositories.RecordRepository.Implementation;
using Homework.Services.DelimiterService;
using Homework.Services.DelimiterService.Implementation;
using Homework.Services.FileService;
using Homework.Services.FileService.Implementation;
using Homework.Services.RecordService.Implementation;
using Homework.Services.RecordService;
using Homework.Services.RecordService.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Homework.App
{
	public class Program
	{
		#region "Public methods"
		public static void Main(string[] args)
		{
			var builder = Host.CreateDefaultBuilder().Build();

			IServiceProvider serviceProvider = new ServiceCollection()
				.AddScoped<IDelimiterRepository, DelimiterRepository>()
				.AddScoped<IFileRepository, FileRepository>()
				.AddScoped<IRecordRepository, RecordRepository>()
				.AddSingleton<IDelimiterService, DelimiterService>()
				.AddSingleton<IFileService, FileService>()
				.AddSingleton<IRecordService, RecordService>()
				.BuildServiceProvider();

			Console.Clear();
			Console.WriteLine("- Query application started.");
			Console.WriteLine();

			// Query the records.
			QueryRecords(serviceProvider);

			Console.WriteLine("- Query application ended.");
			Console.WriteLine();
		}
		#endregion

		#region "Private methods"
		private static void QueryRecords(IServiceProvider serviceProvider)
		{
			Console.WriteLine("  - Querying records...");

			var recordService = serviceProvider.GetService<IRecordService>();
			var response = recordService.GetRecords(new GetRecordsRequest());
		}
		#endregion
	}
}