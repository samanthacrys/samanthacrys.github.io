using Xunit;

namespace TaskScheduler

{
    //This is the unit testing class that checks that the methods located within the TaskService class work
    //as intended. There are 5 tests that go over the main components for the TaskService class.
    public class TaskServiceTest
    {
        //This is a readonly variable that accesses the TaskService class. It is used to create a new task service
        //and create a single instance. This instances helps improve efficiency of the code by setting this to
        //run automatically.
        private readonly TaskService _taskService = new();

        //This test checks that the AddTask method works. The format for the new task is to set the ID, the name,
        //and the description for a single task. It then asserts that this task was created by checking that it is
        //true based on the new task.
        [Fact]
        public void AddTaskTest()
        {
            Task task = new Task("01", "First Task", "First Task Description.");

            Assert.True(_taskService.AddTask(task));
        }

        //This test checks that the DeleteTask method does what it is meant to and removes a task that matches the ID
        //that is entered. This test creates a new task, adds it to the dictonary, runs the DeleteTask and asserts
        //that it did delete the task.
        [Fact]
        public void DeleteTaskTest()
        {
            Task task = new Task("02", "New Task", "Task Description");

            _taskService.AddTask(task);

            Assert.True(_taskService.DeleteTask(task));
        }

        //This tests that the UpdateTaskName method works. This is done by creating a new task that is the focus of
        //the update. It then adds the task to the dictionary and calls upon the task service to update the name with
        //the task that was added and what the new name is. It then asserts that the updated name has been properly
        //add to the system.
        [Fact]
        public void UpdateTaskNameTest()
        {
            Task task = new Task("03", "Third Task", "Third Task Description.");

            _taskService.AddTask(task);

            TaskService.UpdateTaskName(task, "Task 3");

            Assert.Equal("Task 3", _taskService.GetTask("03")?.Name);
        }

        //This tests that the UpdateTaskDesc method works. As with most of the tests, this creates a task that is added
        //to the dictonary for updating. Once the task is added, it calls upon the UpdateTaskDesc method that accepts
        //the new task as the one to update and what the new description is. It then asserts that the descripton was
        //updated with the new information.
        [Fact]
        public void UpdateTaskDescTest()
        {
            Task task = new Task("04", "Task 4", "Task Description.");

            _taskService.AddTask(task);

            TaskService.UpdateTaskDesc(task, "Task 4 Description.");

            Assert.Equal("Task 4 Description.", _taskService.GetTask("04")?.Description);
        }

        //This tests the GetTask method. It starts with creating a new task that is added to the dictionary. Once the
        //task is created, it ensures that it can get the Task by receiving the ID given to that task and that it does
        //equal the information it takes in.
        [Fact]
        public void GetTaskTest()
        {
            Task task = new Task("05", "Task 5", "Task Description.");

            _taskService.AddTask(task);

            Assert.Equal(task, _taskService.GetTask("05"));
        }
    }
}