using GowBoard.Models;
using GowBoard.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GowBoard.Controllers
{
    public class MemberController : Controller
    {
        private MemberDbContext db = new MemberDbContext();

        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        // GET: Member/Register
        // 회원가입
        public ActionResult Register() 
        { 
            return View();
        }

        // Post: Member/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Member member)
        {
            if(ModelState.IsValid)
            {
                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("LogIn", "Member");
            }

            return View(member); 
        }


        // GET: Member/LogIn
        // 로그인
        public ActionResult LogIn() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Member member) 
        {
            var logInMember = db.Member.FirstOrDefault(u => u.MemberId == member.MemberId && u.Password == member.Password);
            if (logInMember != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(member);
        }


        // GET: Member/FindId
        // 아이디 찾기
        public ActionResult FindId()
        {
            return View();
        }

        // GET: Member/NewPassword
        // 비밀번호 재설정
        public ActionResult NewPassword() 
        {
            return View();
        }
    }
}