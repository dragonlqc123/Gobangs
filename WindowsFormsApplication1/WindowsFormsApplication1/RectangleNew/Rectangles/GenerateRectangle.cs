using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    public class GenerateRectangle<Key>
    {
        IRectangle<Key, EntityData<Key>> rectangle;

        Dictionary<Key, EntityData<Key>> _c_Points;
        public GenerateRectangle(int captity, Dictionary<Key, EntityData<Key>> c_Points)
        {
            rectangle = new Rectangle<Key, EntityData<Key>> (captity, new ScatterNode(ScatterNode));
             _c_Points = c_Points;
            InitData();
        }

        public void InitData()
        {
            foreach (Key key in _c_Points.Keys)
            {
                rectangle.AddNode(key, _c_Points[key]);
                break;
            }
        }

        public object ScatterNode(object key)
        {
             Key _key = (Key)key;
            if (_c_Points.ContainsKey(_key))
            {
                return _c_Points[_key];
            }
            return null;
        }

        public IRectangleModel<Key> this[Key key]
        {
            get
            {
                return rectangle.Summary_Get(key);
            }
        }

        public void TestAnalysis(Key key, object condition, SearchTest<Key> searchTest)
        {
             rectangle.TestAnalysis( key,  condition, searchTest);
        }
        #region Console
        public void TestWriteLineAll()
        {
            rectangle.TestWriteLineAll();
        }
        public void WriteLineAllDESC()
        {
            rectangle.WriteLineAllDESC();
        }
        public void WriteLineAllASC()
        {
            rectangle.WriteLineAllASC();
        }
        public void WriteLineAll(Key key)
        {
            rectangle.WriteLineAll(key);
        }
        #endregion
    }
}
