using System;
using System.Linq;
using System.IO;
using Core.Interfaces;
using Foundation;
using QuickLook;
using UIKit;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using Core.iOS.Implementations;

[assembly: Dependency(typeof(FileImplementation))]
namespace Core.iOS.Implementations
{
    public class FileImplementation : IFile
    {
        public async Task OpenFromResource(string name)
        {
            try
            {
				var directory = Path.GetFullPath(
					Path.Combine(
						Assembly.GetExecutingAssembly().Location, "../"
					)
				);
				
				var file = Path.Combine(directory, name);

                if (!File.Exists(file))
                    throw new Exception("The file does not exists.");

				QLPreviewItemBundle prevItem = new QLPreviewItemBundle(name, file);
				QLPreviewController previewController = new QLPreviewController();
				previewController.DataSource = new PreviewControllerDataSource(prevItem);

                var firstController = UIApplication
                    .SharedApplication
                    .KeyWindow
                    .RootViewController
                    .ChildViewControllers
                    .First();

				var navigationController = firstController as UINavigationController;
				await navigationController.PresentViewControllerAsync(previewController, true);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }

	public class PreviewControllerDataSource : QLPreviewControllerDataSource
	{
		private QLPreviewItem _item;

		public PreviewControllerDataSource(QLPreviewItem item)
		{
			_item = item;
		}

		public override System.nint PreviewItemCount(QLPreviewController controller)
		{
			return 1;
		}

		public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, System.nint index)
		{
			return _item;
		}
	}

	public class QLPreviewItemFileSystem : QLPreviewItem
	{
		string _fileName, _filePath;

		public QLPreviewItemFileSystem(string fileName, string filePath)
		{
			_fileName = fileName;
			_filePath = filePath;
		}

		public override string ItemTitle
		{
			get
			{
				return _fileName;
			}
		}

		public override NSUrl ItemUrl
		{
			get
			{
				return NSUrl.FromFilename(_filePath);
			}
		}
	}

	public class QLPreviewItemBundle : QLPreviewItem
	{
		string _fileName, _filePath;

		public QLPreviewItemBundle(string fileName, string filePath)
		{
			_fileName = fileName;
			_filePath = filePath;
		}

		public override string ItemTitle
		{
			get
			{
				return _fileName;
			}
		}

		public override NSUrl ItemUrl
		{
			get
			{
				var documents = NSBundle.MainBundle.BundlePath;
				var lib = Path.Combine(documents, _filePath);
				var url = NSUrl.FromFilename(lib);
				return url;
			}
		}
	}
}
