using StepanovAlexandrKt_41_21.Database;
using StepanovAlexandrKt_41_21.Interfaces.StudentsInterfaces;
using StepanovAlexandrKt_41_21.Models;
using Microsoft.EntityFrameworkCore;

namespace StepanovAlexandrKt_41_21.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3121_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-21"
                },
                new Group
                {
                    GroupName = "KT-41-21"
                },
                new Group
                {
                    GroupName = "KT-42-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    GroupId = 3,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 3,
                },
                new Student
                {
                     FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 3,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "KT-42-21"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(3, studentsResult.Length);
        }

        [Fact]
        public async Task GetStudentsByLastName()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            /*ar groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-21"
                },
                new Group
                {
                    GroupName = "KT-41-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();*/

            // Act
            var filter = new Filters.StudentFilters.StudentLastNameFilter
            {
                LastName = "asdf"
            };
            var studentsResult = await studentService.GetStudentsByLastNameAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, studentsResult.Length);
        }

        [Fact]
        public async Task GetStudentsByFIO()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            /*var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-21"
                },
                new Group
                {
                    GroupName = "KT-41-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();*/

            // Act
            var filter = new Filters.StudentFilters.StudentFIOFilter
            {
                FirstName = "qwerty3",
                LastName = "asdf3",
                MiddleName = "zxc3",
            };
            var studentsResult = await studentService.GetStudentsByFIOAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, studentsResult.Length);
        }
        [Fact]
        public async Task GetStudentsByGroupId()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            /*var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-21"
                },
                new Group
                {
                    GroupName = "KT-41-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();*/

            // Act
            var filter = new Filters.StudentFilters.StudentGroupIdFilter
            {
                GroupId = 3,
            };
            var studentsResult = await studentService.GetStudentsByGroupIdAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(3, studentsResult.Length);
        }
    }
}
