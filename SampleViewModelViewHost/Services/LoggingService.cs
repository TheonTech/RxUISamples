using System;
using System.ComponentModel;
using System.Diagnostics;
using Splat;

namespace SampleViewModelViewHost.Services
{
	public class LoggingService : ILogger
	{
		public LogLevel Level { get; set; }

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			if (logLevel >= Level)
				Debug.WriteLine(message);
		}

		public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
		{
			throw new NotImplementedException();
		}

		public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			throw new NotImplementedException();
		}

		public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			throw new NotImplementedException();
		}
	}
}
