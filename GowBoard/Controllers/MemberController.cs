using GowBoard.Models;
using GowBoard.Models.Context;
using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.Entity;
using GowBoard.Models.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GowBoard.Controllers
{
    public class MemberController : Controller
    {
        // private GowBoardContext db = new GowBoardContext();

        private readonly GowBoardContext _db;
        private readonly IMemberService _memberService;

        public MemberController() { }

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        

        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        // GET: Member/Register
        // 회원가입
        [HttpGet]
        public ActionResult Register() 
        { 
            return View();
        }

        // Post: Member/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ReqMemberDTO member)
        {
            if(ModelState.IsValid)
            {
                bool isRegistered = _memberService.RegisterMember(member);
                if (isRegistered)
                {
                    return RedirectToAction("RegisterSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "Member Info is already taken");
                }
            }

            // TODO: 회원가입이 유효하지 않았을 경우 return 변경
            return View(member); 
        }


        // GET: Member/LogIn
        // 로그인
        public ActionResult LogIn() 
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogIn(Member member) 
        //{
        //    var logInMember = _db.Members.FirstOrDefault(u => u.MemberId == member.MemberId && u.Password == member.Password);
        //    if (logInMember != null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError("", "Invalid username or password");
        //    return View(member);
        //}


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