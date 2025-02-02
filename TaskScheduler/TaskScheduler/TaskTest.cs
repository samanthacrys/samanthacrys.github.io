using Xunit;

namespace TaskScheduler
{
    //This class tests the different features found within the Task class. This ensures that the properties work as
    //they are meant to, that a task can be created, and that the ID, name, and description fall within the parameters
    //they are meant to follow.
    public class TaskTest
    {
        //This tests that, when given the information for a task, it can create the task. It calls upon the Task class
        //to create a new entry. It takes in the 3 parameters for ID, name, and description. The test then asserts that
        //each component equals what was input.
        [Fact]
        public void TaskCreationTest()
        {
            Task task = new Task("Task1", "New Task", "Task Description");

            Assert.Equal("Task1", task.Id);
            Assert.Equal("New Task", task.Name);
            Assert.Equal("Task Description", task.Description);

        }

        //This checks that the length of the ID is <= the maximum length allowed. This is done by creating a new task
        //and then checking if that is true. This was made more efficient by combining two tests together to check
        //that it is <= as opposed to two tests. Previously, it had only checked for less than and another test checked
        //for equal to.
        [Fact]
        public void TaskIdLengthIsLessThanOrEqual()
        {
            Task task = new Task("1", "Task Name", "Description of Task");

            Assert.True(task.Id.Length <= Task.MaxTaskIdLength);
        }

        //This checks that the value in the ID does contain information. The ID for the task should never be
        //null. This is done by creating a new task with the relevant information and then asserts that it isn't null.
        [Fact]
        public void TaskIdIsNotNull()
        {
            Task task = new Task("2", "Task", "Task");

            Assert.NotNull(task.Id);
        }

        //This makes sure that the name of the task is of a valid length. It does this by asserting that a task with
        //a name that's too long throws an exception. If this is the case, it throws that exception. In this case, it
        //includes a name that spells out what is happening.
        [Fact]
        public void InvalidName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Task task = new Task("3", "This is way too long and makes sure " +
                                          "it's valid.", "Task Description");
            });
        }

        //This makes sure that the description is of a valid length. It does this by taking in a new task with a name
        //that's too long and throwing an exception. As with the InvalidName test, the description contains a
        //an explanation on what is happening.
        [Fact]
        public void InvalidDescription()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Task task = new Task("4", "Task Name", "This description is " +
                                                       "definitely too long for this area and should only be 50 " +
                                                       "characters.");
            });
        }

        //This checks that the name of the task is <= the maximum length allowed. This is done by creating a new
        //task and then it asserts that it is true.
        [Fact]
        public void TaskNameLengthIsLessThanOrEqual()
        {
            Task task = new Task("5", "Task Name", "Description of Task");

            Assert.True(task.Name.Length <= Task.MaxTaskNameLength);
        }

        //This checks that the length of the description is valid by comparing it to make sure it's <= the maximum
        //length allowed for the description. This is done by creating a task with a description of a valid length.
        //It compares that length to that maximum value and passes the test when it can assert that this is true.
        [Fact]
        public void TaskDescriptionLengthIsLessThanOrEqual()
        {
            Task task = new Task("5", "Task Name", "Description of Task");

            Assert.True(task.Description.Length <= Task.MaxTaskDescriptionLength);
        }
    }
}