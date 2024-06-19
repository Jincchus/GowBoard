using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GowBoard.Controllers
{
    public class MyPageController : Controller
    {
        // GET: MyPage
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyPage/Profile
        // 프로필 페이지
        public ActionResult Profile() 
        {
            return View();
        }

        // Get: MyPage/UpdateProfile
        // 프로필 수정 페이지
        public ActionResult UpdateProfile() 
        {
            return View();
        }

        // Get: MyPage/MyCommentList
        // 내가 쓴 댓글 리스트 페이지
        public ActionResult MyCommentList() 
        {
            return View();
        }

        // Get: MyPage/MyPostList
        // 내가 쓴 게시글 리스트 페이지
        public ActionResult MyPostList()
        { 
            return View();
        }

        // Get: MyPage/Withdrawal
        // 회원 탈퇴 페이지
        public ActionResult Withdrawal() 
        {
            return View(); 
        }
    }
}using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GowBoard.Controllers
{
    public class MyPageController : Controller
    {
        // GET: MyPage
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyPage/Profile
        // 프로필 페이지
        public ActionResult Profile() 
        {
            return View();
        }

        // Get: MyPage/UpdateProfile
        // 프로필 수정 페이지
        public ActionResult UpdateProfile() 
        {
            return View();
        }

        // Get: MyPage/MyCommentList
        // 내가 쓴 댓글 리스트 페이지
        public ActionResult MyCommentList() 
        {
            return View();
        }

        // Get: MyPage/MyPostList
        // 내가 쓴 게시글 리스트 페이지
        public ActionResult MyPostList()
        { 
            return View();
        }

        // Get: MyPage/Withdrawal
        // 회원 탈퇴 페이지
        public ActionResult Withdrawal() 
        {
            return View(); 
        }
    }
}