using GowBoard.Models.Service;
using GowBoard.Models.Service.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GowBoard
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            
            // 회원가입 Dependencies
            container.RegisterType<IMemberService, MemberService>();


            // Set resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}