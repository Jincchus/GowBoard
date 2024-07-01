using GowBoard.Models.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GowBoard.Controllers
{
    public class MyPageController : Controller
    {
        private readonly IMemberService _memberService;

        public MyPageController(IMemberService memberService)
        {
            _memberService = memberService;
        }


        // GET: MyPage/Profile
        // 프로필 페이지
        public ActionResult Profile() 
        {
            if (Session["MemberId"] != null)
            {
                // 해당 세션 정보(memberId)로 회원 조회
                string memberId = Session["MemberId"].ToString();
                var member = _memberService.GetMemberById(memberId);

                if(member != null)
                {
                    return View(member);
                }
                else
                {
                    ViewBag.ErrorMessage = "잘못된 접근입니다.";
                    return View("Error");
                }
            } else
            {
                ViewBag.ErrorMessage = "로그인한 회원만 이용 가능한 페이지입니다.";
                return RedirectToAction("LogIn", "Member");
            }
        }

        // Get: MyPage/UpdateProfile
        // 프로필 수정 페이지
        public ActionResult UpdateProfile()
        {
            if (Session["MemberId"] != null)
            {
                // 해당 세션 정보(memberId)로 회원 조회
                string memberId = Session["MemberId"].ToString();
                var member = _memberService.GetMemberById(memberId);

                if (member != null)
                {
                    return View(member);
                }
                else
                {
                    ViewBag.ErrorMessage = "잘못된 접근입니다.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "로그인한 회원만 이용 가능한 페이지입니다.";
                return RedirectToAction("LogIn", "Member");
            }
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
        [HttpGet]
        public ActionResult Withdrawal()
        {
            if (Session["MemberId"] != null)
            {
                // 해당 세션 정보(memberId)로 회원 조회
                string memberId = Session["MemberId"].ToString();
                var member = _memberService.GetMemberById(memberId);

                if (member != null)
                {
                    return View(member);
                }
                else
                {
                    ViewBag.ErrorMessage = "잘못된 접근입니다.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "로그인한 회원만 이용 가능한 페이지입니다.";
                return RedirectToAction("LogIn", "Member");
            }
        }

        // POST: MyPage/Withdrawal
        // 회원 탈퇴
        [HttpPost]
        public ActionResult Withdrawal(string password)
        {
            string memberId = Session["MemberId"].ToString();
            var member = _memberService.GetMemberById(memberId);
            bool isPasswordCorrect = _memberService.VerifyPassword(member, password);
            if (!isPasswordCorrect)
            {

            }
            _memberService.DeleteMember(memberId);
            return RedirectToAction("Index", "Home");
        }
    }
}