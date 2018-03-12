using BreakingChangesDetector;
using BreakingChangesDetector.BreakingChanges;
using BreakingChangesDetector.BreakingChanges.Formatting;
using BreakingChangesDetector.MetadataItems;
using BreakingChangesDetector.Serialization;
using BreakingChangesDetector.UnitTests.BreakingChangesTests;
using Infragistics.Documents.RichText;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDriver
{
	public class Program
	{
		static void Main(string[] args)
		{
			//var assemblyData = AssemblyData.GetAssemblyData(typeof(AddedAbstractMemberTests).Assembly);
			//var allAssemblies = AssemblyData.GetAllAssemblies();

			//var family = AssemblyFamily.FromDirectory(@"C:\Work\NetAdvantage\DEV\WinForms\2013.2\Source\Build");

			var family1 = AssemblyFamily.FromDirectory(@"C:\Users\miked\Desktop\FeatureDocuments\Research\BreakingChanges\V1");
			var family2 = AssemblyFamily.FromDirectory(@"C:\Users\miked\Desktop\FeatureDocuments\Research\BreakingChanges\V2");

			//using (var fs = File.Create("data.bin"))
			//	new BinaryItemSerializerV1(fs, family1.GetAllReferencedAssemblies().ToArray());

			//using (var fs = File.OpenRead("data.bin"))
			//{
			//	var d = new BinaryItemDeserializerV1(fs);
			//	var l = d.LoadedAssemblies;
			//}

			var breakingChanges = MetadataComparer.CompareAssemblyFamilies(family1, family2);
			//breakingChanges = breakingChanges.OrderBy(b => b.BreakingChangeKind).ToList();

			var formatter = new BreakingChangeRichTextDocumentFormatter();

			foreach (var breakingChange in breakingChanges)
			{
				breakingChange.FormatMessage(formatter);
				formatter.AppendLine();
			}

			formatter.OnDocumentComplete();

			using (var s = File.Create("Out.docx"))
				formatter.Document.SaveToWord(s);

			Process.Start("Out.docx");
		}

		public static void Foo<T>() { }
	}
}
