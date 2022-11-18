//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Globalization;
	using System.IO;
	using System.Text;
	using System.Threading;
	using System.Xml;


	//********************************************************************************************
	// class XmlFactory
	//********************************************************************************************

	/// <summary>
	/// Creates instances of Xml types by retrieving them from resource assemblies.
	/// </summary>

	public static class ExceptionEncoder
	{

		/// <summary>
		/// Encodes the given Exception as a string suitable for writing to a diagnostic log.
		/// </summary>
		/// <param name="exception">
		/// An Exception or ApplicationException instance.
		/// </param>
		/// <returns>
		/// A string specifying an XML representation of the Exception including AppDomain
		/// and Thread information, exception type, stack trace, data items and inner
		/// exceptions.
		/// </returns>

		public static string Encode (Exception exception)
		{
			var builder = new StringBuilder();
			var writer = new StringWriter(builder);
			var xml = new XmlTextWriter(writer);
			xml.Formatting = Formatting.Indented;

			xml.WriteStartElement("Exception");

			var domain = AppDomain.CurrentDomain;
			xml.WriteStartElement("AppDomain");
			xml.WriteAttributeString("id", domain.Id.ToString());
			xml.WriteString(domain.FriendlyName);
			xml.WriteEndElement();

			var thread = Thread.CurrentThread;
			xml.WriteStartElement("Thread");
			xml.WriteAttributeString("id", thread.ManagedThreadId.ToString());
			xml.WriteString(thread.Name);
			xml.WriteEndElement();

			xml.WriteStartElement("Exception");

			Encode(xml, exception);

			xml.WriteEndElement();
			xml.Close();
			xml = null;
			writer.Close();
			writer = null;

			return builder.ToString();
		}


		private static void Encode (XmlWriter xml, Exception exception)
		{
			Type type = exception.GetType();
			xml.WriteElementString("ExceptionType", Encode(type.AssemblyQualifiedName));
			xml.WriteElementString("Message", Encode(exception.Message));
			xml.WriteElementString("StackTrace", Encode(EncodeStackTrace(exception)));
			xml.WriteElementString("ExceptionString", Encode(exception.ToString()));
			var wex = exception as Win32Exception;
			if (wex != null)
			{
				xml.WriteElementString("NativeErrorCode",
					wex.NativeErrorCode.ToString("X", CultureInfo.InvariantCulture));
			}
			if ((exception.Data != null) && (exception.Data.Count > 0))
			{
				xml.WriteStartElement("DataItems");
				foreach (object key in exception.Data.Keys)
				{
					xml.WriteStartElement("Data");
					xml.WriteElementString("Key", Encode(key.ToString()));

					if (exception.Data[key] == null)
						xml.WriteElementString("Value", "null");
					else
					{
						if (exception.Data.Contains(key))
						{
							xml.WriteElementString("Value", Encode(exception.Data[key].ToString()));
						}
					}

					xml.WriteEndElement();
				}
				xml.WriteEndElement();
			}
			if (exception.InnerException != null)
			{
				xml.WriteStartElement("InnerException");
				Encode(xml, exception.InnerException);
				xml.WriteEndElement();
			}
		}


		private static string EncodeStackTrace (Exception exception)
		{
			string trace = exception.StackTrace;
			if (!string.IsNullOrEmpty(trace))
			{
				return trace;
			}
			int count = 0;
			StackFrame[] frames = new StackTrace(false).GetFrames();
			if (frames != null) // check required by Coverity
			{
				foreach (StackFrame frame in frames)
				{
					string name = frame.GetMethod().Name;
					if ((name != null) && (((name == "StackTraceString") ||
						(name == "AddExceptionToTraceString")) || (((name == "BuildTrace") ||
						(name == "TraceEvent")) || (name == "TraceException"))))
					{
						count++;
					}
					else if ((name != null) &&
						name.StartsWith("ThrowHelper", StringComparison.Ordinal))
					{
						count++;
					}
					else
					{
						break;
					}
				}
			}
			var stackTrace = new StackTrace(count, false);
			return stackTrace.ToString();
		}



		/// <summary>
		/// Transforms any XML specific characters within the given string to their
		/// encoded equivalents, allowing the string to be included as content of an
		/// XML element rather than an element itself or a misaligned token that 
		/// inadvertently corrupts the stream of XML.
		/// </summary>
		/// <param name="text">A string containing XML tokens to encode</param>
		/// <returns>A string with encoded tokens.</returns>

		public static string Encode (string text)
		{
			if (String.IsNullOrEmpty(text))
			{
				return text;
			}

			int len = text.Length;
			var builder = new StringBuilder(len + 8);
			for (int i = 0; i < len; i++)
			{
				char ch = text[i];
				switch (ch)
				{
					case '<':
						builder.Append("&lt;");
						break;

					case '>':
						builder.Append("&gt;");
						break;

					case '&':
						builder.Append("&amp;");
						break;

					default:
						builder.Append(ch);
						break;
				}
			}

			return builder.ToString();
		}
	}
}
