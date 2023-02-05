using AppCore.Data_Access.Entity_Framework.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public abstract class TeacherRepoBase : RepoBase<Teacher>
	{
		protected TeacherRepoBase(MusicSchoolContext dbContext) : base(dbContext)
		{
		}
	}
	public class TeacherRepo : TeacherRepoBase
	{
		public TeacherRepo(MusicSchoolContext dbContext) : base(dbContext)
		{
		}
	}
}
