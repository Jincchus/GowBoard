using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GowBoard.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult index()
        {
            return View();
        }
        // GET: Board/Create
        // 글등록 페이지
        public ActionResult Create() 
        {
            return View();
        }

        // GET: Board/List
        // 게시판 리스트 페이지
        public ActionResult List() {
            return View();
        }

        // GET: Board/DetailView
        // 게시판 디테일 뷰 페이지
        public ActionResult DetailView() 
        {
            return View(); 
        }

        // GET: Board/Update
        // 게시판 업데이트 페이지
        public ActionResult Update() 
        {
            return View();
        }

        //public void Delete(int id) { }



    }
}