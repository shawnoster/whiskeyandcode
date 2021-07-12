using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ListBoxVirtualization
{
    public class VirtualSongList : IList<Song>, IList
    {
        #region IList<Song> Members

        public int IndexOf(Song item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Song item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Song this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection<Song> Members

        public void Add(Song item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Song item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Song[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the total number of items in your list.
        /// </summary>
        public int Count
        {
            get
            {
                return 10000;
            }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Song item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<Song> Members

        public IEnumerator<Song> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();

            //for (int i = 0; i < Count; ++i)
            //{
            //    yield return new Song();
            //}
        }

        #endregion

        #region IList Members

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        object IList.this[int index]
        {
            get
            {
                // here is where the magic happens, create/load your data on the fly.
                Debug.WriteLine("Requsted item " + index.ToString());
                return new Song() { Title = "Song " + index.ToString() };
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
