using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MultiColumnText
{
	public partial class MultiColumnTextViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			int padding = 20;
			var size = new SizeF (View.Bounds.Width / 2 - padding * 2,
				 View.Bounds.Height - padding * 2);

			// create text storage
			var storage = new NSTextStorage ();
			NSDictionary options = null;
			NSError error = null;
		
			storage.ReadFromFile (NSUrl.FromFilename ("Text.txt"), new NSDictionary (), ref options, ref error);

			// create layout manager
			var layoutManager = new NSLayoutManager ();

			// add layout manager to text storage
			storage.AddLayoutManager (layoutManager);

			// create text container
			var leftContainer = new NSTextContainer (size);

			// add text container to layout manager
			layoutManager.AddTextContainer (leftContainer);

			// init text view with text container
			var leftColumn = new UITextView (
				new RectangleF (new PointF (padding, padding), size), 
				leftContainer);

			leftColumn.AutoresizingMask = UIViewAutoresizing.All;

			leftColumn.ScrollEnabled = false;
			View.Add (leftColumn);

			// create another text container
			var rightContainer = new NSTextContainer (size);

			// add second text container to layout manager
			layoutManager.AddTextContainer (rightContainer);

			// init text view with second text container
			var rightColumn = new UITextView (
				new RectangleF (new PointF (padding * 2 + size.Width, padding), size), 
				rightContainer);

			rightColumn.AutoresizingMask = UIViewAutoresizing.All;

			View.Add (rightColumn);

			// add some text addtributes
			leftColumn.TextStorage.BeginEditing ();
			leftColumn.TextStorage.AddAttribute(UIStringAttributeKey.ForegroundColor, UIColor.Green, new NSRange(200, 400));
			leftColumn.TextStorage.AddAttribute(UIStringAttributeKey.BackgroundColor, UIColor.Black, new NSRange(210, 300));
			leftColumn.TextStorage.EndEditing ();
		}
	}
}

