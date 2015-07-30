using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Xna.Framework
{
    public sealed class GameComponentCollection : IList<IGameComponent>
    {
        //Since our DrawOrder & UpdateOrder are independent, if we want to 
        //perform updates and draws in the correct order, we have two options
        // 1) Sort every cycle (slower, but simpler)
        // 2) Maintain Two Lists (a bit more complex and bug-prone, but more efficient) 

        List<IGameComponent> _components = new List<IGameComponent>();
        List<IUpdateable> _updateableComponents = new List<IUpdateable>();
        List<IDrawable> _drawableComponents = new List<IDrawable>();
        List<IUpdateable> _tempUpdateableComponents = new List<IUpdateable>();
        List<IDrawable> _tempDrawableComponents = new List<IDrawable>();
        //Used to decouple the sorting from the actual
        //update of the sort order.  Necessary since
        //the sort order can be updated while iterating 
        //throw a list.  We don't want to change the 
        //list at that time.
        bool _updateSortOrder = false;
		bool _exiting;
		Game _game;

        internal void Refresh()
        {
            if (_updateSortOrder)
            {
                for (int i = 0; i < _drawableComponents.Count; i++)
                {
                    var c = _drawableComponents[i];
                    if (c is GameComponent)
                    {
                        (c as GameComponent).previousDrawSortIndex = i;
                    }
                }
                _drawableComponents.Sort(SortDrawOrder);
                for (int i = 0; i < _updateableComponents.Count; i++)
                {
                    var c = _updateableComponents[i];
                    if (c is GameComponent)
                    {
                        (c as GameComponent).previousUpdateSortIndex = i;
                    }
                }
                _updateableComponents.Sort(SortUpdateOrder);
                _updateSortOrder = false;
            }
        }

        static int SortDrawOrder(IDrawable c1, IDrawable c2)
        {
            if (c1.DrawOrder == c2.DrawOrder)
            {
                if (!(c1 is GameComponent) || !(c2 is GameComponent))
                {
                    return 0;
                }
                else
                {
                    return ((c1 as GameComponent).previousDrawSortIndex < (c2 as GameComponent).previousDrawSortIndex) ? -1 : 1;
                }
            }

            return (c1.DrawOrder < c2.DrawOrder) ? -1 : 1;
        }

        static int SortUpdateOrder(IUpdateable gc1, IUpdateable gc2)
        {
            if (gc1.UpdateOrder == gc2.UpdateOrder)
            {
                if (!(gc1 is GameComponent) || !(gc2 is GameComponent))
                {
                    return 0;
                }
                else
                {
                    return ((gc1 as GameComponent).previousUpdateSortIndex < (gc2 as GameComponent).previousUpdateSortIndex) ? -1 : 1;
                }
            }

            return (gc1.UpdateOrder < gc2.UpdateOrder) ? -1 : 1;
        }


        public int IndexOf(IGameComponent item)
        {
            return _components.IndexOf(item);
        }

        public void Insert(int index, IGameComponent item)
        {
            _components.Insert(index, item);
            item.Initialize();

            IUpdateable ugc = item as IUpdateable;
            if (ugc != null)
            {
                _updateableComponents.Add(ugc);
                ugc.UpdateOrderChanged += item_Updated;
            }

            DrawableGameComponent dgc = item as DrawableGameComponent;
            if (dgc != null)
            {
                _drawableComponents.Add(dgc);
                dgc.DrawOrderChanged += item_Updated;
            }

            _updateSortOrder = true;
        }

        //Need to decouple the changing of the sort order from 
        //the actual changes to the properties.
        void item_Updated(object sender, EventArgs e)
        {
            _updateSortOrder = true;
        }

        public void RemoveAt(int index)
        {
            if (index > _components.Count - 1)
                throw new IndexOutOfRangeException();

            IUpdateable removedUpdateableComponent = _components[index] as IUpdateable;
            if (removedUpdateableComponent != null)
            {
                _updateableComponents.Remove(removedUpdateableComponent);
            }

            IDrawable removedDrawableComponent = _components[index] as IDrawable;
            if (removedDrawableComponent != null)
            {
                _drawableComponents.Remove(removedDrawableComponent);
            }

            _components.RemoveAt(index);
        }

        public bool Remove(IGameComponent item)
        {
            if (item is IUpdateable)
            {
                _updateableComponents.Remove(item as IUpdateable);
            }

            if (item is IDrawable)
            {
                _drawableComponents.Remove(item as IDrawable);
            }
            if (ComponentRemoved != null) ComponentRemoved(this, new GameComponentCollectionEventArgs(item));

            return _components.Remove(item);
        }

        public IGameComponent this[int index]
        {
            get
            {
                return _components[index];
            }
            set
            {
                _components[index] = value;
            }
        }

        public void Add(IGameComponent item)
        {
            _components.Add(item);

            IUpdateable ugc = item as IUpdateable;
            if (ugc != null)
            {
                _updateableComponents.Add(ugc);
                ugc.UpdateOrderChanged += item_Updated;
            }

            IDrawable dgc = item as IDrawable;
            if (dgc != null)
            {
                _drawableComponents.Add(dgc);
                dgc.DrawOrderChanged += item_Updated;
            }

            _updateSortOrder = true;
            Refresh();
        }

        public void Clear()
        {
            var tmp = _components.ToList();
            _components.Clear();
            _updateableComponents.Clear();
            _drawableComponents.Clear();
            foreach (var c in tmp)
            {
                if (ComponentRemoved != null) ComponentRemoved(this, new GameComponentCollectionEventArgs(c));
            }
        }

        public bool Contains(IGameComponent item)
        {
            return _components.Contains(item);
        }

        public void CopyTo(IGameComponent[] array, int arrayIndex)
        {
            _components.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _components.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Update(GameTime gameTime)
        {
			if (_exiting) return;
            _tempUpdateableComponents.Clear();
            for (int i = 0; i < _updateableComponents.Count; i++)
            {
				if (_updateableComponents[i] is GameComponent)
				{
					(_updateableComponents[i] as GameComponent).BeforeUpdate();
				}

				if (_updateableComponents[i].Enabled)
                {
                    _tempUpdateableComponents.Add(_updateableComponents[i]);
                }
            }

            for(int i = 0; i < _tempUpdateableComponents.Count; i++)
            {
				if (_exiting) break;
				GameComponent gc = _tempUpdateableComponents[i] as GameComponent;
                if (gc != null)
                {
                    if (gc._initialized == false) gc.Initialize();
                    gc.Update(gameTime);
                }
            }

            Refresh();
        }

        public void Draw(GameTime gameTime)
        {
			if (_exiting) return;
			IUpdateable uc;
            if (_tempDrawableComponents.Count > 0) _tempDrawableComponents.Clear();
            for (int i = 0; i < _drawableComponents.Count; i++)
            {
                uc = _drawableComponents[i] as IUpdateable;
                if (_drawableComponents[i].Visible && (uc == null || uc.Enabled))
                {
                    _tempDrawableComponents.Add(_drawableComponents[i]);
                }
            }

            for(int i = 0; i < _tempDrawableComponents.Count; i++)
            {
                if (_exiting) break;
                IDrawable dc = _tempDrawableComponents[i];
                GameComponent gc = _tempDrawableComponents[i] as GameComponent;
                {
                    if (gc._initialized == false) gc.Initialize();
                }
                dc.Draw(gameTime);
            }

            Refresh();
        }

        public void Initialize(Game game)
        {
			_game = game;
			_game.Exiting += new EventHandler(_game_Exiting);
            foreach (IGameComponent gc in _components)
            {
                gc.Initialize();
            }

            Refresh();
        }

		void _game_Exiting(object sender, EventArgs e)
		{
			_game.Exiting -= new EventHandler(_game_Exiting);
			_exiting = true;
		}

        public IEnumerator<IGameComponent> GetEnumerator()
        {
            return _components.GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        public event EventHandler<GameComponentCollectionEventArgs> ComponentRemoved;
    }

    public class GameComponentCollectionEventArgs : EventArgs
    {
        public GameComponentCollectionEventArgs(IGameComponent gameComponent)
        {
            this.GameComponent = gameComponent;
        }

        public IGameComponent GameComponent { get; private set; }
    }


}
