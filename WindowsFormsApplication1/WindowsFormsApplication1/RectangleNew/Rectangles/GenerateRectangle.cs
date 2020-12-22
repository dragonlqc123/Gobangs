using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.RectangleNew.Rectangles
{
    /// <summary>
    /// 添加总体扫描
    /// 添加查询个数总数；
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    public class GenerateRectangle<Key>
    {
        private IRectangle<Key, EntityData<Key>> rectangle;
        private Dictionary<Key, EntityData<Key>> _c_Points;
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

        public EntityData<Key> TestAnalysis(Key key, object condition, SearchTest<Key> searchTest)
        {
           return rectangle.TestAnalysis(key, condition, searchTest);
        }
        public EntityData<Key> Analysis(Key key, object condition)
        {
            return rectangle.Analysis(key, condition);
        }

        public EntityData<Key> Analysis(object attackCondition, object defenseCondition, GetAll<Key> getAll,Key key)
        {
            return rectangle.Analysis(attackCondition, defenseCondition, getAll, key);
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
