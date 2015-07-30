using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace SilverArcade.SilverSprite.Graphics
{
	public class DirtyQuad
	{
		public Rectangle BoundingRect;
		public bool IsDirty;
		public bool AllDirty;
		public DirtyQuad[] Nodes;
		public bool HasChildren;
		public int Index;
		public DirtyQuad Parent;
		public DirtyQuad Next;

		public DirtyQuad(Rectangle rect)
		{
			BoundingRect = rect;
			if (false)
			//			if (rect.Width > 128 && rect.Height > 128)
			{
				Nodes = new DirtyQuad[4];
				int w0 = rect.Width / 2;
				int w1 = rect.Width - w0;
				int h0 = rect.Height / 2;
				int h1 = rect.Height - h0;
				int x = rect.X;
				int y = rect.Y;
				Rectangle childRect0 = new Rectangle(x, y, w0, h0);
				Nodes[0] = new DirtyQuad(childRect0);
				Rectangle childRect1 = new Rectangle(x + w0, y, w1, h0);
				Nodes[1] = new DirtyQuad(childRect1);
				Rectangle childRect2 = new Rectangle(x, y + h0, w0, h1);
				Nodes[2] = new DirtyQuad(childRect2);
				Rectangle childRect3 = new Rectangle(x + w0, y + h0, w1, h1);
				Nodes[3] = new DirtyQuad(childRect3);
				for (int i = 0; i < 4; i++)
				{
					Nodes[i].Index = i;
					Nodes[i].Parent = this;
					if (i < 3)
					{
						Nodes[i].Next = Nodes[i + 1];
					}
				}
				HasChildren = true;
			}
		}

		public void SetClean()
		{
			this.IsDirty = false;
			this.AllDirty = false;
			if (HasChildren)
			{
				Nodes[0].SetClean();
				Nodes[1].SetClean();
				Nodes[2].SetClean();
				Nodes[3].SetClean();
			}
		}

		public bool NeedsRedraw(ref Rectangle rect)
		{
			if (IsDirty == false) return false;
			if (BoundingRect.Intersects(rect) == false) return false;
			if (AllDirty) return true;
			if (HasChildren)
			{
				if (Nodes[0].NeedsRedraw(ref rect)) return true;
				if (Nodes[1].NeedsRedraw(ref rect)) return true;
				if (Nodes[2].NeedsRedraw(ref rect)) return true;
				if (Nodes[3].NeedsRedraw(ref rect)) return true;
			}
			return false;
		}

		public void InvalidateAll()
		{
			AllDirty = true;
		}

		public void Invalidate(ref Rectangle rect)
		{
			if (AllDirty) return;
			if (BoundingRect.Intersects(rect) == false) return;
			IsDirty = true;
			if (HasChildren == false)
			{
				AllDirty = true;
				return;
			}
			Nodes[0].Invalidate(ref rect);
			Nodes[1].Invalidate(ref rect);
			Nodes[2].Invalidate(ref rect);
			Nodes[3].Invalidate(ref rect);
			AllDirty = Nodes[0].AllDirty && Nodes[1].AllDirty && Nodes[2].AllDirty && Nodes[3].AllDirty;
		}

		public override string ToString()
		{
			return string.Format("IsDirty: {0}, AllDirty: {1}", IsDirty, AllDirty);
		}

		DirtyQuad GetNextNode(DirtyQuad current)
		{
			DirtyQuad next = current.Next;
			if (next != null) return next;
			if (current.Parent == null) return null;
			return GetNextNode(current.Parent);			
		}

		public IEnumerable<DirtyQuad> GetDirtyQuads(Rectangle rect)
		{
			if (AllDirty)
			{
				yield return this;
			}
			else
			{
				DirtyQuad current = this;
				DirtyQuad next = this;
				while (current != null)
				{
					if (current.BoundingRect.Intersects(rect) == false)
					{
						current = GetNextNode(current);
					}
					else if (current.AllDirty)
					{
						yield return current;
						current = GetNextNode(current);
					}
					else if (current.IsDirty && current.HasChildren)
					{
						current = current.Nodes[0];
					}
					else
					{
						current = GetNextNode(current);
					}
				}
			}
		}
	}
}
