------------------------把通过sql语句查询到的datatable转换为entity或list<entity> 用于作为API的返回json结果--------------------------------

public static class DataConvert<T> where T : new()
    {
        /// <summary>
        /// 将DataRow行转换成Entity
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ToEntity(DataRow dr)
        {
            T entity = new T();
            Type info = typeof(T);
            var members = info.GetMembers();
            foreach (var mi in members)
            {
                if (mi.MemberType == MemberTypes.Property)
                {
                    //读取属性上的DataField特性
                    object[] attributes = mi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                    foreach (var attr in attributes)
                    {
                        if (attr is DataFieldAttribute dataFieldAttr)
                        {
                            var propInfo = info.GetProperty(mi.Name);
                            if (dr.Table.Columns.Contains(dataFieldAttr.ColumnName))
                            {
                                //根据ColumnName，将dr中的相对字段赋值给Entity属性
                                propInfo.SetValue(entity,
                                    Convert.ChangeType(dr[dataFieldAttr.ColumnName], propInfo.PropertyType),
                                    null);
                            }

                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 将DataTable转换成Entity列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList(DataTable dt)
        {
            List<T> list = new List<T>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToEntity(dr));
            }
            return list;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DataFieldAttribute : Attribute
    {
        /// <summary>
        /// 表对应的字段名
        /// </summary>
        public string ColumnName { set; get; }

        public DataFieldAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
