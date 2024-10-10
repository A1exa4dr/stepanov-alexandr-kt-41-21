using Microsoft.EntityFrameworkCore;
using StepanovAlexandrKt_41_21.Database;
using StepanovAlexandrKt_41_21.Filters.StudentFilters;
using StepanovAlexandrKt_41_21.Models;

namespace StepanovAlexandrKt_41_21.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByGroupIdAsync(StudentGroupIdFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByLastNameAsync(StudentLastNameFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsIsDeletedAsync(StudentDeletedFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByGroupIdAsync(StudentGroupIdFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupId == filter.GroupId).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.LastName == filter.LastName &&
                                                             w.LastName == filter.LastName &&
                                                             w.MiddleName == filter.MiddleName)
                                                    .ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByLastNameAsync(StudentLastNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.LastName == filter.LastName).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.FirstName == filter.FirstName && w.IsDeleted == false).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student[]> GetStudentsIsDeletedAsync(StudentDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.IsDeleted == filter.IsDeleted).ToArrayAsync(cancellationToken);

            return students;
        }
    }
}
