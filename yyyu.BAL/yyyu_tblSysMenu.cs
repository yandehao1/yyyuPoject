using System;
using System.Data;
using System.Collections.Generic;
using yyyu.Common;
using yyyu.Model;
namespace yyyu.BLL
{
    /// <summary>
    /// yyyu_tblSysMenu
    /// </summary>
    public partial class yyyu_tblSysMenu
    {
        private readonly yyyu.DAL.yyyu_tblSysMenu dal = new yyyu.DAL.yyyu_tblSysMenu();
        public yyyu_tblSysMenu()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Menu_Id)
        {
            return dal.Exists(Menu_Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(yyyu.Model.yyyu_tblSysMenu model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yyyu.Model.yyyu_tblSysMenu model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Menu_Id)
        {

            return dal.Delete(Menu_Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(yyyu.Common.PageValidate.SafeLongFilter(IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public yyyu.Model.yyyu_tblSysMenu GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public yyyu.Model.yyyu_tblSysMenu GetModelByCache(int ID)
        {
            string CacheKey = "yyyu_tblSysMenuModel-" + ID;
            object objModel = yyyu.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = yyyu.Common.ConfigHelper.GetConfigInt("ModelCache");
                        yyyu.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (yyyu.Model.yyyu_tblSysMenu)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<yyyu.Model.yyyu_tblSysMenu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<yyyu.Model.yyyu_tblSysMenu> DataTableToList(DataTable dt)
        {
            List<yyyu.Model.yyyu_tblSysMenu> modelList = new List<yyyu.Model.yyyu_tblSysMenu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yyyu.Model.yyyu_tblSysMenu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public string GetMuenList()
        {
            //获取数据
            DataSet ds = this.GetList("IsActive=1");
            Dictionary<string, Model.yyyu.TreeObejct> dicTreeObejct = new Dictionary<string, Model.yyyu.TreeObejct>();//数据存储
            string strJson = "";
            //菜单数据大于0
            if (ds.Tables[0].Rows.Count > 0)
            {
                //先获取添加父节点信息
                DataView dv = ds.Tables[0].DefaultView;//获取视图
                dv.RowFilter = "Menu_ParentId=-1 AND Menu_Level=1";
                DataTable dt = dv.ToTable();
                foreach (DataRow item in dt.Rows)
                {
                    Model.yyyu.TreeObejct mp = new Model.yyyu.TreeObejct();
                    //添加父节点
                    if (item["Menu_ParentId"].ToString() == "-1")
                    {
                        mp.Menu_Id = item["Menu_Id"].ToString();
                        mp.Menu_ParentId = item["Menu_ParentId"].ToString();
                        mp.Name = item["Name"].ToString();
                        mp.ShowName = item["ShowName"].ToString();
                        mp.MeunNum = item["MeunNum"].ToString();
                        if (item["NodeUrl"] == null)
                        {
                            mp.NodeUrl = "";
                        }
                        else
                        {
                            mp.NodeUrl = item["NodeUrl"].ToString();
                        }
                        mp.IshasSon = item["IshasSon"].ToString();
                        mp.children =new List<Model.yyyu.TreeObejct>();
                        dicTreeObejct.Add(mp.Menu_Id, mp);//将数据插入到list中
                    }
                }
                //获取所有子节点的数据
                DataView dv1 = ds.Tables[0].DefaultView;//获取子节点视图
                dv1.RowFilter = "Menu_ParentId<>-1";
                DataTable dt1 = dv1.ToTable();
                if (dt1.Rows.Count>0)
                {
                    //根据父节点添加子节点
                    foreach (var dicTree in dicTreeObejct)
                    {
                        foreach (DataRow dr  in dt1.Rows)
                        {
                            if (dicTree.Value.Menu_Id==dr["Menu_ParentId"].ToString())
                            {
                                Model.yyyu.TreeObejct mp = new Model.yyyu.TreeObejct();
                                mp.Menu_Id = dr["Menu_Id"].ToString();
                                mp.Menu_ParentId = dr["Menu_ParentId"].ToString();
                                mp.Name = dr["Name"].ToString();
                                mp.ShowName = dr["ShowName"].ToString();
                                mp.MeunNum = dr["MeunNum"].ToString();
                                if (dr["NodeUrl"] == null)
                                {
                                    mp.NodeUrl = "";
                                }
                                else
                                {
                                    mp.NodeUrl = dr["NodeUrl"].ToString();
                                }
                                mp.IshasSon = dr["IshasSon"].ToString();
                                dicTreeObejct[dicTree.Value.Menu_Id].children.Add(mp);
                            }
                        }

                    }
                }
               strJson=yyyu.Common.JsonHelper.SerializationStr(dicTreeObejct);
            }
            else
            {

            }
            return strJson;
        }

        /// <summary>
        /// 获取父级菜单的节点
        /// </summary>
        /// <returns></returns>
        public string GetMuenPidList() 
        {
            DataSet ds = this.GetList("IsActive=1 AND Menu_ParentId=-1 AND Menu_Level=1");//获取父节点数据
            Dictionary<string, Model.yyyu.TreeObejct> dicTreeObejct = new Dictionary<string, Model.yyyu.TreeObejct>();//数据存储
            string strJson = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Model.yyyu.TreeObejct mp = new Model.yyyu.TreeObejct();
                    //添加父节点
                    if (item["Menu_ParentId"].ToString() == "-1")
                    {
                        mp.Menu_Id = item["Menu_Id"].ToString();
                        mp.Menu_ParentId = item["Menu_ParentId"].ToString();
                        mp.Name = item["Name"].ToString();
                        mp.ShowName = item["ShowName"].ToString();
                        mp.MeunNum = item["MeunNum"].ToString();
                        if (item["NodeUrl"] == null)
                        {
                            mp.NodeUrl = "";
                        }
                        else
                        {
                            mp.NodeUrl = item["NodeUrl"].ToString();
                        }
                        mp.IshasSon = item["IshasSon"].ToString();
                        mp.children = new List<Model.yyyu.TreeObejct>();
                        dicTreeObejct.Add(mp.Menu_Id, mp);//将数据插入到list中
                    }
                }
                strJson = yyyu.Common.JsonHelper.SerializationStr(dicTreeObejct);
            }
            return strJson;
        }
        #endregion  ExtensionMethod
    }
}

