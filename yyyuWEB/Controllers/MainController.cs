using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace yyyuWEB.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取菜单栏的父节点
        /// </summary>
        /// <returns></returns>
        public JsonResult MenuJson() 
        {
            //获取菜单
            yyyu.BLL.yyyu_tblSysMenu sysmenu = new yyyu.BLL.yyyu_tblSysMenu();
            string strJson=sysmenu.GetMuenPidList();
            return Json(strJson,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取父菜单栏下面的子菜单栏
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult SumMenuJson(string pid) 
        {
            yyyu.BLL.yyyu_tblSysMenu bll = new yyyu.BLL.yyyu_tblSysMenu();
            string strJson = bll.GetMenuSonList(pid);
            return Json(strJson, JsonRequestBehavior.AllowGet);
        }

        //递归读取菜单
        public string GetMenu() 
        {
            yyyu.BLL.yyyu_tblSysMenu bll=new yyyu.BLL.yyyu_tblSysMenu();
            DataSet ds = bll.GetList("IsActive=1");//获取数据
            List<yyyu.Common.TreeList.TreeObject> list = GetPNode(ds);//转换数据为树结构
            //传入list,转化为HTML代码输出
            string strJson = MenuForHtml(list);
            return strJson;
        }
        /// <summary>
        /// 将list转化为菜单栏的数据，输出到界面上
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string MenuForHtml(List<yyyu.Common.TreeList.TreeObject> list) 
        {
            string html = "";
            StringBuilder sb = new StringBuilder();
            if (list.Count>0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sb.Append("<li class=''>");//菜单li
                    if (list[i].url=="")
                    {
                        sb.Append("<a href='#' class='dropdown-toggle'>");
                    }
                    else
                    {
                        sb.Append("<a href='"+list[i].url.ToString()+"' class='dropdown-toggle'>");
                    }
                    sb.Append("<i class='menu-icon fa fa-desktop'></i>");
                    sb.Append("<span class='menu-text'>"+list[i].ShowName+"</span>");
                    sb.Append("<b class='arrow fa fa-angle-down'></b>");
                    sb.Append("</a>");
                    sb.Append("<b class='arrow'></b>");
                    if (list[i].Children.Count>0)
                    {
                       sb.Append(MenuForSonHtml(list[i].Children));
                    }
                }
                html = sb.ToString();
            }
            return html;
        }

        public string MenuForSonHtml(List<yyyu.Common.TreeList.TreeObject> list) 
        {
            string str = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='submenu'>");
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append("<li class=''>");
                if (list[i].url=="")
                {
                    sb.Append("<a href='#' class='dropdown-toggle'>");
                }
                else
                {
                    sb.Append("<a href='" + list[i].url.ToString()+ "' class='dropdown-toggle'>");
                }
                sb.Append("<i class='menu-icon fa fa-caret-right'></i>");
                sb.Append(list[i].ShowName);
                sb.Append("<b class='arrow fa fa-angle-down'></b>"); 
                sb.Append("</a>");
                sb.Append("<b class='arrow'></b>");
                if (list[i].Children.Count>0)
                {
                    sb.Append(MenuForSonHtml(list[i].Children));
                }
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            str=sb.ToString();
            return str;
        }
        /// <summary>
        /// 将DataTable获取到的值转化为树级结构list
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<yyyu.Common.TreeList.TreeObject> GetPNode(DataSet ds) 
        {
            List<yyyu.Common.TreeList.TreeObject> list = new List<yyyu.Common.TreeList.TreeObject>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["Menu_ParentId"].ToString() == "-1")
                    {
                        yyyu.Common.TreeList.TreeObject tree = new yyyu.Common.TreeList.TreeObject();
                        tree.Id = ds.Tables[0].Rows[i]["Menu_Id"].ToString();
                        tree.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                        tree.ShowName = ds.Tables[0].Rows[i]["ShowName"].ToString();
                        if (ds.Tables[0].Rows[i]["NodeUrl"].ToString() == "" || ds.Tables[0].Rows[i]["NodeUrl"] == null)
                        {
                            tree.url = "";
                        }
                        else
                        {
                            tree.url = ds.Tables[0].Rows[i]["NodeUrl"].ToString();
                        }
                        tree.Pid = "-1";
                        tree.Children = GetChild(tree.Id);
                        list.Add(tree);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 递归获取子节点
        /// </summary>
        /// <param name="pid">父节点参数</param>
        /// <returns></returns>
        private List<yyyu.Common.TreeList.TreeObject> GetChild(string pid) 
        {
            yyyu.BLL.yyyu_tblSysMenu bll=new yyyu.BLL.yyyu_tblSysMenu();
            DataTable dt = bll.GetList("Menu_ParentId=" + pid).Tables[0];//获取数据
            List<yyyu.Common.TreeList.TreeObject> list = new List<yyyu.Common.TreeList.TreeObject>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yyyu.Common.TreeList.TreeObject tree = new yyyu.Common.TreeList.TreeObject();
                tree.Id = dt.Rows[i]["Menu_Id"].ToString();
                tree.Name = dt.Rows[i]["Name"].ToString();
                tree.Pid = dt.Rows[i]["Menu_ParentId"].ToString();
                tree.ShowName = dt.Rows[i]["ShowName"].ToString();
                if (dt.Rows[i]["NodeUrl"].ToString() == "" || dt.Rows[i]["NodeUrl"] == null)
                {
                    tree.url = "";
                }
                else
                {
                    tree.url = dt.Rows[i]["NodeUrl"].ToString();
                }
                DataTable dt1 = bll.GetList("Menu_ParentId=" + tree.Id).Tables[0];//获取数据
                if (dt1!=null)
                {
                    tree.Children = GetChild(tree.Id);
                }
                list.Add(tree);
            }
            return list;
        }

        public ActionResult Defult()
        {
            return View();
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Main/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
